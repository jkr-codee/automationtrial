using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.AutomationTrial.Infrastructure.Entity
{
    /// <summary>
    /// JSON Deserializer for the Rest API https://jsonplaceholder.typicode.com/posts
    /// </summary>
    public class Post
    {
        public int? UserId { get; set; }
        public int? Id { get; set; }

        public String Title { get; set; }

        public String Body { get; set; }
    }
}
