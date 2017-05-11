using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Credential")]
    [Serializable] // moi truyen session
    public class Credential
    {
        [Key]
        [StringLength(20)]
         public string UserGroupID { get; set; }

         public string RoleID { get; set; }

    }
}
