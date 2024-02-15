using System.ComponentModel.DataAnnotations;

namespace TrackingTasks.Models
{
    public class WorkTask
    {

        [Key]

        public int Id { get; set; }

        public string workTaskName { get; set; }    
        
        public DateTime workTaskDueDate { get; set;}

        public string workTaskStatus { get; set;}

       
    }
}
