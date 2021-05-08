using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace reporting.Models
{
    public class LogActivity
    {
        public Guid Id;
        public Guid CorrelationId;
        public Guid RequestId;
        public string Service;
        public string Activity;
        public string ActivityDetail;
        public DateTime Timestamp;



        public override string ToString()
        {
            return $"LogActivity[Id: {this.Id}, CorrelationId:{this.CorrelationId}, RequestId:{this.RequestId}, Service:{this.Service}, Activity:{this.Activity}, ActivityDetail:{this.ActivityDetail}, Timestamp:{this.Timestamp.ToShortDateString()} ]";
        }
    }
}
