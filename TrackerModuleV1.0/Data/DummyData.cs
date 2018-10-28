using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackerModuleV1._0.Models.PTM;

namespace TrackerModuleV1._0.Data
{
    public class DummyData
    {
        public static List<Project> getProjects()
        {
            List<Project> projects = new List<Project>()
            {
                new Project()
                {
                    ProjectName="Wafer Sorter",
                    users=new List<User>(),
                    parts=new List<Part>()

                },
                new Project()
                {
                    ProjectName="Bakeout Chamber",
                    users=new List<User>(),
                    parts=new List<Part>()
                },
                new Project()
                {
                    ProjectName="Process Kit Transporter",
                    users=new List<User>(),
                    parts=new List<Part>()
                },
                new Project()
                {
                    ProjectName="Carbon Nanotube CVD Chamber",
                    users=new List<User>(),
                    parts=new List<Part>()
                }
            };
            return projects;
            
         }
        public static List<User> getUsers()
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    FirstName="Leo",
                    LastName="Passion",
                    JobRole="Engineer",
                    
                   // projects=new List<Project>()
                    //ProjectNumber=context.Projects.Find(3).ProjectId,
                    
                },
                new User()
                {
                    FirstName="Abienash",
                    LastName="Thangavel",
                    JobRole="Design Engineer",
                     //projects=new List<Project>()
                   // ProjectNumber=context.Projects.Find(1).ProjectId,

                },
                new User()
                {
                    FirstName="Alex",
                    LastName="Daniel",
                    JobRole="Design Engineer",
                     projects=new List<Project>()
                    //ProjectNumber=context.Projects.Find(1).ProjectId,

                },
                new User()
                {
                    FirstName="Danny",
                    LastName="Edward",
                    JobRole="Design Engineer",
                    // projects=new List<Project>()
                    //ProjectNumber=context.Projects.Find(1).ProjectId,

                },
                new User()
                {
                    FirstName="Devinda",
                    LastName="Liyanage",
                    JobRole="R@D Engineer",
                     //projects=new List<Project>()
                   // ProjectNumber=context.Projects.Find(4).ProjectId,

                },
                new User()
                {
                    FirstName="Chamali",
                    LastName="Liyanage",
                    JobRole="R@D Engineer",
                     //projects=new List<Project>()
                   // ProjectNumber=context.Projects.Find(4).ProjectId,

                }
            };
            return users;
        }

        public static List<Part> getParts(PTMContex contex)
        {
            List<Part> parts = new List<Part>()
            {
                new Part()
                {
                    PartName="ScrewDriver",
                    PartDescription="Triwing Triangle Screw-Driver Repair Fixing Tool for Nintendo Wii DS Lite NDSL",
                    NovenaTecPartNumber="NOVSCREW1001",
                    SwissRanksPartNumber="SWSCREW1001",
                    OEMPartNumber="OEMSCREW1001",
                    VendorPartNumber="ABCSCREW1001",
                    CreatedBy= contex.Users.Find(2),
                    ApproveBy=contex.Users.Find(1),
                    Status="Approved",
                    StockQuantity=10
                    

                },

                new Part()
                {
                    PartName="BreadBoard",
                    PartDescription="Round Hole Solderless Breadboard 840 Points",
                    NovenaTecPartNumber="NOVBBOARD1002",
                    SwissRanksPartNumber="SWBBOARD1002",
                    OEMPartNumber="OEMBBOARD1002",
                    VendorPartNumber="FXYBBOARD1002",
                    CreatedBy= contex.Users.Find(1),
                    Status="Send for Approve",
                    StockQuantity=0

                }
            };

            return parts;
        }

    }
}