using Simurgh.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simurgh.DAL
{
    public class StaticData
    {
        public static List<Client> Clients = new List<Client>{
            new Client()
            {
                Id=1,
                ClientName="Lorikeet Family",
                ClientDescription = "Lorikeet family is living in remote places of Sistan and Balouchestan province of Iran. They are disadvantaged from basic living amenities and utilities plus they are deprived from any kind of money making activities.",
                Avatar = "images/projects/1/lorikeet1.jpg",
                GoogleMapAddress="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d4391842.965895599!2d58.789367776186324!3d28.22707811997935!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3ee7373a9afe43d5%3A0xe92f486ae9df1408!2sSistan+and+Baluchestan+Province%2C+Iran!5e1!3m2!1sen!2sus!4v1560554452394!5m2!1sen!2sus",
                Pictures=new List<Picture>(){
                    new Picture(){ Id = 1, Type=PictureType.Video,  Url = "https://www.youtube.com/embed/QMmZtIEZ05c?rel=0&cc_load_policy=1"}
                },
            },
            new Client()
            {
                Id=2,
                ClientName="Kookaburra Family",
                ClientDescription = "Kookaburra family is in need of basic amenities as well...",
                Avatar = "images/projects/2/kookaburra1.jpg",
                GoogleMapAddress="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d4391842.965895599!2d58.789367776186324!3d28.22707811997935!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3ee7373a9afe43d5%3A0xe92f486ae9df1408!2sSistan+and+Baluchestan+Province%2C+Iran!5e1!3m2!1sen!2sus!4v1560554452394!5m2!1sen!2sus",
            },
            new Client()
            {
                Id=3,
                ClientName="Magpie Family",
                ClientDescription = "This family needs some repairs to be done on their house.",
                Avatar = "images/projects/3/magpie1.jpg",
                GoogleMapAddress="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d4391842.965895599!2d58.789367776186324!3d28.22707811997935!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3ee7373a9afe43d5%3A0xe92f486ae9df1408!2sSistan+and+Baluchestan+Province%2C+Iran!5e1!3m2!1sen!2sus!4v1560554452394!5m2!1sen!2sus",
            },
        };

        public static List<Project> Projects = new List<Project>
        {
            new Project()
            {
                Id = 1,
                ClientId =1,
                Name = "Building Bathroom and Shower",
                Description ="In this project we will build a Bathroom and Shower for this family.",
                ProjectStage = Stage.Execution,
                Pictures = new List<Picture>()
                {
                    new Picture(){Id=2 ,Type= PictureType.Image, Url="images/projects/1/location00.jpeg"},
                    new Picture(){Id=3 ,Type= PictureType.Image, Url="images/projects/1/location01.jpeg"},
                    new Picture(){Id=4 ,Type= PictureType.Video, Url="https://www.youtube.com/embed/y11XYVF6yfE?rel=0&cc_load_policy=1"},
                    new Picture(){Id=5 ,Type= PictureType.Video, Url="https://www.youtube.com/embed/QMmZtIEZ05c?rel=0&cc_load_policy=1"},
                    new Picture(){Id=6 ,Type= PictureType.Image, Url="images/projects/1/location02.jpeg"},
                    new Picture(){Id=7 ,Type= PictureType.Image, Url="images/projects/1/location03.jpeg"},
                    new Picture(){Id=8 ,Type= PictureType.Image, Url="images/projects/1/location04.jpeg"},
                    new Picture(){Id=9 ,Type= PictureType.Image, Url="images/projects/1/location05.jpeg"},
                    new Picture(){Id=10,Type= PictureType.Image, Url="images/projects/1/location06.jpeg"},
                    new Picture(){Id=11,Type= PictureType.Image, Url="images/projects/1/location07.jfif"},
                    new Picture(){Id=12,Type= PictureType.Image, Url="images/projects/1/location08.jfif"},
                },
            },

            new Project()
            {
                Id = 2,
                ClientId =1,
                Name = "Building a kitchen area",
                Description ="In this project we will build a decent kitchen area for this family.",
                ProjectStage = Stage.MoneyRaising,
            },

            new Project()
            {
                Id = 3,
                ClientId =1,
                Name = "Painting room and fixing roof",
                Description ="In this project we will  paint the room and fix the roof for this family.",
                ProjectStage = Stage.MoneyRaising,
            },
        };


    }
}
