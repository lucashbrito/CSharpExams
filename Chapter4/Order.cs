﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chapter4
{
    [Serializable]
    public class Order
    {
        [XmlAttribute]
        public int ID { get; set; }
        [XmlIgnore]
        public bool IsDirty { get; set; }
        [XmlArray("Lines")]
        [XmlArrayItem("OrderLine")]
        public List<OrderLine> OrderLines { get; set; }
    }

    [Serializable]
    public class OrderLine
    {
        [XmlAttribute]
        public int ID { get; set; }
        [XmlAttribute]
        public int Amount { get; set; }
        [XmlElement("OrderedProduct")]
        public Product Product { get; set; }
    }

    [Serializable]
    public class Product
    {
        [XmlAttribute]
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    [Serializable]
    public class VIPOrder : Order
    {
        public string Description { get; set; }
    }

    [Serializable]
    public class People
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
