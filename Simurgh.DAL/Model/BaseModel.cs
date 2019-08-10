using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Simurgh.DAL.Model
{
    /// <summary>
    /// Note:
    /// All subclasses should have a constructor with zero parameters because of
    /// reflection that was used in repository
    /// </summary>
    public class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public BaseModel()
        {

        }
    }
}
