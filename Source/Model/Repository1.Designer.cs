﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("FoodOrderDatabaseModel", "InventoryItemId", "InventoryItem", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(FoodOrder.Model.InventoryItem), "TransactionOrderItem", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(FoodOrder.Model.TransactionOrderItem), true)]
[assembly: EdmRelationshipAttribute("FoodOrderDatabaseModel", "TransactionId", "Transaction", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(FoodOrder.Model.Transaction), "TransactionOrderItem", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(FoodOrder.Model.TransactionOrderItem), true)]

#endregion

namespace FoodOrder.Model
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class FoodOrderDatabaseEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new FoodOrderDatabaseEntities object using the connection string found in the 'FoodOrderDatabaseEntities' section of the application configuration file.
        /// </summary>
        public FoodOrderDatabaseEntities() : base("name=FoodOrderDatabaseEntities", "FoodOrderDatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new FoodOrderDatabaseEntities object.
        /// </summary>
        public FoodOrderDatabaseEntities(string connectionString) : base(connectionString, "FoodOrderDatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new FoodOrderDatabaseEntities object.
        /// </summary>
        public FoodOrderDatabaseEntities(EntityConnection connection) : base(connection, "FoodOrderDatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<InventoryItem> InventoryItems
        {
            get
            {
                if ((_InventoryItems == null))
                {
                    _InventoryItems = base.CreateObjectSet<InventoryItem>("InventoryItems");
                }
                return _InventoryItems;
            }
        }
        private ObjectSet<InventoryItem> _InventoryItems;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Transaction> Transactions
        {
            get
            {
                if ((_Transactions == null))
                {
                    _Transactions = base.CreateObjectSet<Transaction>("Transactions");
                }
                return _Transactions;
            }
        }
        private ObjectSet<Transaction> _Transactions;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TransactionOrderItem> TransactionOrderItems
        {
            get
            {
                if ((_TransactionOrderItems == null))
                {
                    _TransactionOrderItems = base.CreateObjectSet<TransactionOrderItem>("TransactionOrderItems");
                }
                return _TransactionOrderItems;
            }
        }
        private ObjectSet<TransactionOrderItem> _TransactionOrderItems;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<User> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<User>("Users");
                }
                return _Users;
            }
        }
        private ObjectSet<User> _Users;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the InventoryItems EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToInventoryItems(InventoryItem inventoryItem)
        {
            base.AddObject("InventoryItems", inventoryItem);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Transactions EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTransactions(Transaction transaction)
        {
            base.AddObject("Transactions", transaction);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the TransactionOrderItems EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTransactionOrderItems(TransactionOrderItem transactionOrderItem)
        {
            base.AddObject("TransactionOrderItems", transactionOrderItem);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUsers(User user)
        {
            base.AddObject("Users", user);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="FoodOrderDatabaseModel", Name="InventoryItem")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class InventoryItem : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new InventoryItem object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="type">Initial value of the type property.</param>
        /// <param name="name">Initial value of the name property.</param>
        public static InventoryItem CreateInventoryItem(global::System.Int32 id, global::System.String type, global::System.String name)
        {
            InventoryItem inventoryItem = new InventoryItem();
            inventoryItem.id = id;
            inventoryItem.type = type;
            inventoryItem.name = name;
            return inventoryItem;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String type
        {
            get
            {
                return _type;
            }
            set
            {
                OntypeChanging(value);
                ReportPropertyChanging("type");
                _type = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("type");
                OntypeChanged();
            }
        }
        private global::System.String _type;
        partial void OntypeChanging(global::System.String value);
        partial void OntypeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FoodOrderDatabaseModel", "InventoryItemId", "TransactionOrderItem")]
        public EntityCollection<TransactionOrderItem> TransactionOrderItems
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<TransactionOrderItem>("FoodOrderDatabaseModel.InventoryItemId", "TransactionOrderItem");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<TransactionOrderItem>("FoodOrderDatabaseModel.InventoryItemId", "TransactionOrderItem", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="FoodOrderDatabaseModel", Name="Transaction")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Transaction : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Transaction object.
        /// </summary>
        /// <param name="finalprice">Initial value of the finalprice property.</param>
        /// <param name="paymentoption">Initial value of the paymentoption property.</param>
        /// <param name="id">Initial value of the id property.</param>
        public static Transaction CreateTransaction(global::System.String finalprice, global::System.String paymentoption, global::System.Int32 id)
        {
            Transaction transaction = new Transaction();
            transaction.finalprice = finalprice;
            transaction.paymentoption = paymentoption;
            transaction.id = id;
            return transaction;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String finalprice
        {
            get
            {
                return _finalprice;
            }
            set
            {
                OnfinalpriceChanging(value);
                ReportPropertyChanging("finalprice");
                _finalprice = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("finalprice");
                OnfinalpriceChanged();
            }
        }
        private global::System.String _finalprice;
        partial void OnfinalpriceChanging(global::System.String value);
        partial void OnfinalpriceChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String paymentoption
        {
            get
            {
                return _paymentoption;
            }
            set
            {
                OnpaymentoptionChanging(value);
                ReportPropertyChanging("paymentoption");
                _paymentoption = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("paymentoption");
                OnpaymentoptionChanged();
            }
        }
        private global::System.String _paymentoption;
        partial void OnpaymentoptionChanging(global::System.String value);
        partial void OnpaymentoptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String cardnumber
        {
            get
            {
                return _cardnumber;
            }
            set
            {
                OncardnumberChanging(value);
                ReportPropertyChanging("cardnumber");
                _cardnumber = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cardnumber");
                OncardnumberChanged();
            }
        }
        private global::System.String _cardnumber;
        partial void OncardnumberChanging(global::System.String value);
        partial void OncardnumberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String cardexpiration
        {
            get
            {
                return _cardexpiration;
            }
            set
            {
                OncardexpirationChanging(value);
                ReportPropertyChanging("cardexpiration");
                _cardexpiration = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cardexpiration");
                OncardexpirationChanged();
            }
        }
        private global::System.String _cardexpiration;
        partial void OncardexpirationChanging(global::System.String value);
        partial void OncardexpirationChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String cardholdername
        {
            get
            {
                return _cardholdername;
            }
            set
            {
                OncardholdernameChanging(value);
                ReportPropertyChanging("cardholdername");
                _cardholdername = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cardholdername");
                OncardholdernameChanged();
            }
        }
        private global::System.String _cardholdername;
        partial void OncardholdernameChanging(global::System.String value);
        partial void OncardholdernameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FoodOrderDatabaseModel", "TransactionId", "TransactionOrderItem")]
        public EntityCollection<TransactionOrderItem> TransactionOrderItems
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<TransactionOrderItem>("FoodOrderDatabaseModel.TransactionId", "TransactionOrderItem");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<TransactionOrderItem>("FoodOrderDatabaseModel.TransactionId", "TransactionOrderItem", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="FoodOrderDatabaseModel", Name="TransactionOrderItem")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TransactionOrderItem : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new TransactionOrderItem object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="inventoryitemid">Initial value of the inventoryitemid property.</param>
        /// <param name="transactionid">Initial value of the transactionid property.</param>
        public static TransactionOrderItem CreateTransactionOrderItem(global::System.Int32 id, global::System.Int32 inventoryitemid, global::System.Int32 transactionid)
        {
            TransactionOrderItem transactionOrderItem = new TransactionOrderItem();
            transactionOrderItem.id = id;
            transactionOrderItem.inventoryitemid = inventoryitemid;
            transactionOrderItem.transactionid = transactionid;
            return transactionOrderItem;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 inventoryitemid
        {
            get
            {
                return _inventoryitemid;
            }
            set
            {
                OninventoryitemidChanging(value);
                ReportPropertyChanging("inventoryitemid");
                _inventoryitemid = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("inventoryitemid");
                OninventoryitemidChanged();
            }
        }
        private global::System.Int32 _inventoryitemid;
        partial void OninventoryitemidChanging(global::System.Int32 value);
        partial void OninventoryitemidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 transactionid
        {
            get
            {
                return _transactionid;
            }
            set
            {
                OntransactionidChanging(value);
                ReportPropertyChanging("transactionid");
                _transactionid = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("transactionid");
                OntransactionidChanged();
            }
        }
        private global::System.Int32 _transactionid;
        partial void OntransactionidChanging(global::System.Int32 value);
        partial void OntransactionidChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FoodOrderDatabaseModel", "InventoryItemId", "InventoryItem")]
        public InventoryItem InventoryItem
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<InventoryItem>("FoodOrderDatabaseModel.InventoryItemId", "InventoryItem").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<InventoryItem>("FoodOrderDatabaseModel.InventoryItemId", "InventoryItem").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<InventoryItem> InventoryItemReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<InventoryItem>("FoodOrderDatabaseModel.InventoryItemId", "InventoryItem");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<InventoryItem>("FoodOrderDatabaseModel.InventoryItemId", "InventoryItem", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FoodOrderDatabaseModel", "TransactionId", "Transaction")]
        public Transaction Transaction
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Transaction>("FoodOrderDatabaseModel.TransactionId", "Transaction").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Transaction>("FoodOrderDatabaseModel.TransactionId", "Transaction").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Transaction> TransactionReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Transaction>("FoodOrderDatabaseModel.TransactionId", "Transaction");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Transaction>("FoodOrderDatabaseModel.TransactionId", "Transaction", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="FoodOrderDatabaseModel", Name="User")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class User : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new User object.
        /// </summary>
        /// <param name="username">Initial value of the username property.</param>
        /// <param name="password">Initial value of the password property.</param>
        /// <param name="firstname">Initial value of the firstname property.</param>
        /// <param name="lastname">Initial value of the lastname property.</param>
        public static User CreateUser(global::System.String username, global::System.String password, global::System.String firstname, global::System.String lastname)
        {
            User user = new User();
            user.username = username;
            user.password = password;
            user.firstname = firstname;
            user.lastname = lastname;
            return user;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String username
        {
            get
            {
                return _username;
            }
            set
            {
                if (_username != value)
                {
                    OnusernameChanging(value);
                    ReportPropertyChanging("username");
                    _username = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("username");
                    OnusernameChanged();
                }
            }
        }
        private global::System.String _username;
        partial void OnusernameChanging(global::System.String value);
        partial void OnusernameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String password
        {
            get
            {
                return _password;
            }
            set
            {
                OnpasswordChanging(value);
                ReportPropertyChanging("password");
                _password = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("password");
                OnpasswordChanged();
            }
        }
        private global::System.String _password;
        partial void OnpasswordChanging(global::System.String value);
        partial void OnpasswordChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                OnfirstnameChanging(value);
                ReportPropertyChanging("firstname");
                _firstname = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("firstname");
                OnfirstnameChanged();
            }
        }
        private global::System.String _firstname;
        partial void OnfirstnameChanging(global::System.String value);
        partial void OnfirstnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                OnlastnameChanging(value);
                ReportPropertyChanging("lastname");
                _lastname = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("lastname");
                OnlastnameChanged();
            }
        }
        private global::System.String _lastname;
        partial void OnlastnameChanging(global::System.String value);
        partial void OnlastnameChanged();

        #endregion
    
    }

    #endregion
    
}
