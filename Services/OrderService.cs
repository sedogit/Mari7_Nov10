using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mari7.Entities;
using Mari7.Models;
using Mari7.Helpers;
using Microsoft.AspNetCore.Http;

namespace Mari7.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order GetOrder(long orderId);
        Order CreateOrder(Order order);

        Order UpdateOrder(Order order);

        bool DeleteOrder(long orderId);
        
         Order SetNewStep(long orderId, int newStepId, int orderStatus, int actionId);    

        Order ClearAssignedUser(long orderId);

     
    }


    public class OrderService : IOrderService
    {
        private readonly MariContext _context;

        private readonly AppSettings _appSettings;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(IOptions<AppSettings> appSettings, MariContext context,IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public IEnumerable<Order> GetAll(){
            return _context.Orders;
        }

        public Order GetOrder(long orderId){
            return _context.Orders.FirstOrDefault(x=>x.ID==orderId);
        }
        public Order CreateOrder(Order order){            

            _context.Orders.Add(order);         /* */   
            _context.SaveChanges();
            // /* orderin detayları üzerinde dönüp onları da kaydedeceğiz */
            // foreach(var item in order.OrderDetail)
            // {
            // _context.Orders.Add(item);         /* */   
            // _context.SaveChanges();
            // }
            return order;
        }

        public Order UpdateOrder(Order order){

            return order;
        }

       public bool DeleteOrder(long orderId){
           return true;
       }
        private void SetOrderActionUserId(Order order, long userId,int stepId){
                switch (stepId)
                {
                    case Step.OrderEntry:
                    order.EntryUserID = userId;
                    break;
                    case Step.PriceAsk:
                    order.PriceAskUserID = userId;
                    break;
                     case Step.PartialPriceAsk:
                    order.PriceAskUserID = userId;
                    break;
                     case Step.SaleOffer:
                    order.SaleOfferUserID = userId;
                    break;                  
                     case Step.SaleApproval:
                    order.SaleApprovedUserID = userId;
                    break;
                       case Step.PurchasePlace:
                    order.PurchasePlacedUserD = userId;
                    break;
                     case Step.PurchaseReceive:
                    order.OperationUserID = userId;
                    break;
                       case Step.OrderDelivery:
                        order.DeliveryUserID = userId;
                    break;
                       case Step.Invoice:
                        order.AccountantUserID = userId;
                    break;                   
                }
        }
        public Order SetNewStep(long orderId, int newStepId, int orderStatus, int actionId){
                       
            long.TryParse(_httpContextAccessor.HttpContext.User.Identity.Name, out var currentUserId);
            var updtOrder = _context.Orders.FirstOrDefault(x=>x.ID==orderId);

            var oldStepID = updtOrder.CurrentStepID; /* current stepID si artık eski step olcak */
            
            updtOrder.CurrentUserID = 0;/* yeni adımda sıfırlıyoruz, kullanıcı kendisi havuzdan çekcek */
            updtOrder.OrderStatus = orderStatus;
            updtOrder.PrevStepID = oldStepID; /* şuanki step, artık prev step olacak */
            updtOrder.CurrentStepID = newStepId;      /* new step  */      
            updtOrder.UpdateUser = currentUserId;
            updtOrder.UpdateDate = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            /* Prev step için, o stepe özel kullancı alanını setleme için bu metoda gidioruz. */
            SetOrderActionUserId(updtOrder,currentUserId,oldStepID);
            
            

            /* Tamamladığımız adımın bilgilerini yazıyoruz. Bir çeşit history */
            OrderStep step = new OrderStep();
            step.StepID 		 = oldStepID;            
            step.OrderID         = orderId;
            step.UserID          = currentUserId;
            step.OrderStatus     = orderStatus;
            step.ActionID        = actionId;
            step.ActionUserID    = currentUserId;
            step.InsertUser      = currentUserId;
            step.UpdateUser      =currentUserId;
            step.UpdateDate      =  long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));;
            step.InsertDate      =  long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));;
            
            /* Db context insert/update edioruz */
            _context.Orders.Update(updtOrder);
            _context.OrderSteps.Add(step);
            _context.SaveChanges();

            return new Order();
        }    

        public Order ClearAssignedUser(long orderId){
            return new Order();
        }


    }
}