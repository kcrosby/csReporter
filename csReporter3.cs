﻿/*
MIT License

Copyright (c) 2017 David Cassady

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

//using System;
//using System.Collections.Generic;
//using System.Collections.Concurrent;
//using System.ComponentModel;
//using System.Text;
//using System.Threading;
//using System.Xml;



//namespace csReporter
//{
//    class csObject
//    {
//        private int strCSdn;
//        private int strID;
//        private int strObjectType;
//        private Delta unappliedExport;
//        private Delta escrowedExport;
//        private Delta unconfirmedExport;
//        private Delta pendingImport;
//        private Entry syncHologram;
//        private Entry unappliedExportHologram;
//        private Entry escrowedExportHologram;
//        private Entry unconfirmedExportHologram;
//        private Entry pendingImportHologram;
//        private bool? bConnector;
//        private int strConnState;
//        private bool bImportSeen;
//        private bool bRebuilding;
//        private bool bObsoletion;
//        private bool bNeedFS;
//        private bool bPlaceHolderParent;
//        private bool bPlaceHolderLink;
//        private bool bPlaceHolderDelete;
//        private bool bPending;
//        private bool bRefRetry;
//        private bool bRenameRetry;
//        private int strImportDeltaOp;
//        private int strExportDeltaOp;
//        private bool bPendingRefDelete;
//        private int strMAid;
//        private int strMAname;
//        private int strPartionID;
//        private int strDisconnectionType;
//        private int strDisconnectionID;
//        private DateTime disconTime;
//        private DateTime lastImportDeltaTime;
//        private DateTime lastExportDeltaTime;
//        private int strFQDN;
//        private int strDomain;
//        private int strAccountName;
//        private int strPartitionName;
//        private Sequencer csSequencer;
//        private int strUPN;
//        private DateTime connectedTime;
//        private int connectionOperation;
//        private ExportError exportError;
//        private StringContainer strContainer;

//        public csObject(XmlNode csObjectNode)
//        {
//            try
//            {
//                strContainer = new StringContainer(100);
//                foreach (XmlAttribute xmlAttr in csObjectNode.Attributes)
//                {
//                    switch (xmlAttr.Name)
//                    {
//                        case "cs-dn":
//                            strCSdn = strContainer.Add(xmlAttr.Value);
//                            break;
//                        case "object-type":
//                            strObjectType = strContainer.Add(xmlAttr.Value);
//                            break;
//                        case "id":
//                            strID = strContainer.Add(xmlAttr.Value);
//                            break;
//                    }
//                }

//                foreach (XmlNode childNode in csObjectNode.ChildNodes)
//                {
//                    switch (childNode.Name)
//                    {
//                        case "connector":
//                            bConnector = Convert.ToBoolean(Convert.ToInt16(childNode.InnerText));
//                            break;
//                        case "connector-state":
//                            strConnState = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "seen-by-import":
//                            bImportSeen = Convert.ToBoolean(Convert.ToInt16(childNode.InnerText));
//                            break;
//                        case "rebuild-in-progress":
//                            bRebuilding = Convert.ToBoolean(Convert.ToInt16(childNode.InnerText));
//                            break;
//                        case "obsoletion":
//                            bObsoletion = Convert.ToBoolean(Convert.ToInt16(childNode.InnerText));
//                            break;
//                        case "need-full-sync":
//                            bNeedFS = Convert.ToBoolean(Convert.ToInt16(childNode.InnerText));
//                            break;
//                        case "placeholder-parent":
//                            bPlaceHolderParent = Convert.ToBoolean(Convert.ToInt16(childNode.InnerText));
//                            break;
//                        case "placeholder-link":
//                            bPlaceHolderLink = Convert.ToBoolean(Convert.ToInt16(childNode.InnerText));
//                            break;
//                        case "placeholder-delete":
//                            bPlaceHolderDelete = Convert.ToBoolean(Convert.ToInt16(childNode.InnerText));
//                            break;
//                        case "pending":
//                            bPending = Convert.ToBoolean(Convert.ToInt16(childNode.InnerText));
//                            break;
//                        case "ref-retry":
//                            bRefRetry = Convert.ToBoolean(Convert.ToInt16(childNode.InnerText));
//                            break;
//                        case "rename-retry":
//                            bRenameRetry = Convert.ToBoolean(Convert.ToInt16(childNode.InnerText));
//                            break;
//                        case "import-delta-operation":
//                            strImportDeltaOp = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "export-delta-operation":
//                            strExportDeltaOp = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "pending-ref-delete":
//                            bPendingRefDelete = Convert.ToBoolean(Convert.ToInt16(childNode.InnerText));
//                            break;
//                        case "ma-id":
//                            strMAid = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "ma-name":
//                            strMAname = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "partition-id":
//                            strPartionID = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "disconnection-type":
//                            strDisconnectionType = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "disconnection-id":
//                            strDisconnectionID = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "disconnection-time":
//                            disconTime = Convert.ToDateTime(childNode.InnerText);
//                            break;
//                        case "last-import-delta-time":
//                            lastImportDeltaTime = Convert.ToDateTime(childNode.InnerText);
//                            break;
//                        case "last-export-delta-time":
//                            lastExportDeltaTime = Convert.ToDateTime(childNode.InnerText);
//                            break;
//                        case "full-qualified-domain-name":
//                            strFQDN = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "domain-name":
//                            strDomain = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "account-name":
//                            strAccountName = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "partition-name":
//                            strPartitionName = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "user-principal-name":
//                            strUPN = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "cs-mv-links":
//                            foreach (XmlNode subNode in childNode)
//                            {
//                                if (subNode.Name == "cs-mv-value")
//                                {
//                                    foreach (XmlAttribute xmlAttr in subNode.Attributes)
//                                    {
//                                        switch (xmlAttr.Name)
//                                        {
//                                            case "lineage-time":
//                                                connectedTime = Convert.ToDateTime(xmlAttr.Value);
//                                                break;
//                                            case "lineage-type":
//                                                connectionOperation = strContainer.Add(xmlAttr.Value);
//                                                break;
//                                        }
//                                    }
//                                }
//                            }
//                            break;
//                        case "mv-link":
//                            foreach (XmlAttribute xmlAttr in childNode.Attributes)
//                            {
//                                switch (xmlAttr.Name)
//                                {
//                                    case "lineage-time":
//                                        connectedTime = Convert.ToDateTime(xmlAttr.Value);
//                                        break;
//                                    case "lineage-type":
//                                        connectionOperation = strContainer.Add(xmlAttr.Value);
//                                        break;
//                                }
//                            }
//                            break;
//                        case "unapplied-export":
//                            unappliedExport = new Delta(childNode.FirstChild, strContainer);
//                            break;
//                        case "escrowed-export":
//                            escrowedExport = new Delta(childNode.FirstChild, strContainer);
//                            break;
//                        case "unconfirmed-export":
//                            unconfirmedExport = new Delta(childNode.FirstChild, strContainer);
//                            break;
//                        case "pending-import":
//                            pendingImport = new Delta(childNode.FirstChild, strContainer);
//                            break;
//                        case "synchronized-hologram":
//                            if (childNode.FirstChild != null)
//                            {
//                                syncHologram = new Entry(childNode.FirstChild, this, strContainer);
//                            }
//                            break;
//                        case "unapplied-export-hologram":
//                            if (childNode.FirstChild != null)
//                            {
//                                unappliedExportHologram = new Entry(childNode.FirstChild, this, strContainer);
//                            }
//                            break;
//                        case "escrowed-export-hologram":
//                            if (childNode.FirstChild != null)
//                            {
//                                escrowedExportHologram = new Entry(childNode.FirstChild, this, strContainer);
//                            }
//                            break;
//                        case "unconfirmed-export-hologram":
//                            if (childNode.FirstChild != null)
//                            {
//                                unconfirmedExportHologram = new Entry(childNode.FirstChild, this, strContainer);
//                            }
//                            break;
//                        case "pending-import-hologram":
//                            if (childNode.FirstChild != null)
//                            {
//                                pendingImportHologram = new Entry(childNode.FirstChild, this, strContainer);
//                            }
//                            break;
//                        case "sequencers":
//                            csSequencer = new Sequencer(childNode);
//                            break;
//                        case "export-errordetail":
//                            exportError = new ExportError(childNode);
//                            break;
//                    }
//                }
//                strContainer.TrimExcess();
//                //if (syncHologram == null)              { syncHologram = new Entry(); }
//                //if (unappliedExportHologram == null)   { unappliedExportHologram = new Entry(); }
//                //if (escrowedExportHologram == null)    { escrowedExportHologram = new Entry(); }
//                //if (unconfirmedExportHologram == null) { unconfirmedExportHologram = new Entry(); }
//                //if (pendingImportHologram == null)     { pendingImportHologram = new Entry(); }
//            }
//            catch (Exception ex)
//            {
//                if (strContainer[strCSdn] != null)
//                {
//                    throw new Exception("Error occurred in csObject object constructor.  csDN=" + strCSdn, ex);
//                }
//                else
//                {
//                    throw new Exception("Error occurred in csObject object constructor.", ex);
//                }
//            }
//        }

//        public string csDN
//        {
//            get
//            {
//                return strContainer[strCSdn];
//            }
//        }
//        public string ObjectType
//        {
//            get
//            {
//                return strContainer[strObjectType];
//            }
//        }
//        public string ID
//        {
//            get
//            {
//                return strContainer[strID];
//            }
//        }
//        public bool? Connector
//        {
//            get
//            {
//                return bConnector;
//            }
//        }
//        public string ConnectorState
//        {
//            get
//            {
//                return strContainer[strConnState];
//            }
//        }
//        public bool ImportSeen
//        {
//            get
//            {
//                return bImportSeen;
//            }
//        }
//        public bool Rebuilding
//        {
//            get
//            {
//                return bRebuilding;
//            }
//        }
//        public bool Obsoletion
//        {
//            get
//            {
//                return bObsoletion;
//            }
//        }
//        public bool NeedFullSync
//        {
//            get
//            {
//                return bNeedFS;
//            }
//        }
//        public bool PlaceHolderParent
//        {
//            get
//            {
//                return bPlaceHolderParent;
//            }
//        }
//        public bool PlaceHolderLink
//        {
//            get
//            {
//                return bPlaceHolderLink;
//            }
//        }
//        public bool PlaceHolderDelete
//        {
//            get
//            {
//                return bPlaceHolderDelete;
//            }
//        }
//        public bool Pending
//        {
//            get
//            {
//                return Pending;
//            }
//        }
//        public bool ReferenceRetry
//        {
//            get
//            {
//                return bRefRetry;
//            }
//        }
//        public bool RenameRetry
//        {
//            get
//            {
//                return bRenameRetry;
//            }
//        }
//        public string ImportDeltaOperation
//        {
//            get
//            {
//                return strContainer[strImportDeltaOp];
//            }
//        }
//        public string ExportDeltaOperation
//        {
//            get
//            {
//                return strContainer[strExportDeltaOp];
//            }
//        }
//        public bool PendingRefeDelete
//        {
//            get
//            {
//                return bPendingRefDelete;
//            }
//        }
//        public string MAid
//        {
//            get
//            {
//                return strContainer[strMAid];
//            }
//        }
//        public string MAname
//        {
//            get
//            {
//                return strContainer[strMAname];
//            }
//        }
//        public string PartitionID
//        {
//            get
//            {
//                return strContainer[strPartionID];
//            }
//        }
//        public string DisconnectionType
//        {
//            get
//            {
//                return strContainer[strDisconnectionType];
//            }
//        }
//        public string DisconnectionID
//        {
//            get
//            {
//                return strContainer[strDisconnectionID];
//            }
//        }
//        public DateTime DisconnectionTime
//        {
//            get
//            {
//                return disconTime;
//            }
//        }
//        public DateTime LastImportDeltaTime
//        {
//            get
//            {
//                return lastImportDeltaTime;
//            }
//        }
//        public DateTime LastExportDeltaTime
//        {
//            get
//            {
//                return lastImportDeltaTime;
//            }
//        }
//        public string FQDN
//        {
//            get
//            {
//                return strContainer[strFQDN];
//            }
//        }
//        public string Domain
//        {
//            get
//            {
//                return strContainer[strDomain];
//            }
//        }
//        public string AccountName
//        {
//            get
//            {
//                return strContainer[strAccountName];
//            }
//        }
//        public string PartitionName
//        {
//            get
//            {
//                return strContainer[strPartitionName];
//            }
//        }
//        public Delta UnappliedExport
//        {
//            get
//            {
//                return unappliedExport;
//            }
//        }
//        public Delta EscrowedExport
//        {
//            get
//            {
//                return escrowedExport;
//            }
//        }
//        public Delta UnconfirmedExport
//        {
//            get
//            {
//                return unconfirmedExport;
//            }
//        }
//        public Delta PendingImport
//        {
//            get
//            {
//                return pendingImport;
//            }
//        }
//        public Delta Delta(State state)
//        {
//            switch (state)
//            {
//                case State.EscrowedExport:
//                    return escrowedExport;
//                case State.None:
//                    return null;
//                case State.PendingImport:
//                    return pendingImport;
//                case State.UnappliedExport:
//                    return unappliedExport;
//                case State.UnconfirmedExport:
//                    return unconfirmedExport;
//                default:
//                    return null;
//            }
//        }
//        public Entry SynchronizedHologram
//        {
//            get
//            {
//                return syncHologram;
//            }
//        }
//        public Entry UnappliedExportHologram
//        {
//            get
//            {
//                return unappliedExportHologram;
//            }
//        }
//        public Entry EscrowedExportHologram
//        {
//            get
//            {
//                return escrowedExportHologram;
//            }
//        }
//        public Entry UnconfirmedExportHologram
//        {
//            get
//            {
//                return unconfirmedExportHologram;
//            }
//        }
//        public Entry PendingImportHologram
//        {
//            get
//            {
//                return pendingImportHologram;
//            }
//        }
//        public Entry Hologram(State state)
//        {
//            switch (state)
//            {
//                case State.EscrowedExport:
//                    return escrowedExportHologram;
//                case State.None:
//                    return syncHologram;
//                case State.PendingImport:
//                    return pendingImportHologram;
//                case State.UnappliedExport:
//                    return unappliedExportHologram;
//                case State.UnconfirmedExport:
//                    return unconfirmedExportHologram;
//                default:
//                    return null;
//            }
//        }
//        public Sequencer Sequencers
//        {
//            get
//            {
//                return csSequencer;
//            }
//        }
//        public string UserPrincipalName
//        {
//            get
//            {
//                return strContainer[strUPN];
//            }
//        }
//        public DateTime ConnectionTime
//        {
//            get
//            {
//                return connectedTime;
//            }
//        }
//        public string ConnectionOperation
//        {
//            get
//            {
//                return strContainer[connectionOperation];
//            }
//        }
//        public ExportError ExportError
//        {
//            get
//            {
//                return exportError;
//            }
//        }
//        public StringContainer Container
//        {
//            get
//            {
//                return strContainer;
//            }
//        }
//    }

//    class Delta
//    {
//        private operation opOperation;
//        private int strDN;
//        private List<Attribute> attr = new List<Attribute>();
//        private StringContainer strContainer;

//        public Delta(XmlNode deltaNode, StringContainer container)
//        {
//            try
//            {
//                strContainer = container;
//                foreach (XmlAttribute xmlAttr in deltaNode.Attributes)
//                {
//                    switch (xmlAttr.Name)
//                    {
//                        case "operation":
//                            switch (xmlAttr.Value)
//                            {
//                                case "delete-add":
//                                    opOperation = operation.deleteAdd;
//                                    break;
//                                case "add":
//                                    opOperation = operation.add;
//                                    break;
//                                case "replace":
//                                    opOperation = operation.replace;
//                                    break;
//                                case "update":
//                                    opOperation = operation.update;
//                                    break;
//                                case "delete":
//                                    opOperation = operation.delete;
//                                    break;
//                                case "none":
//                                    opOperation = operation.none;
//                                    break;
//                            }
//                            break;
//                        case "dn":
//                            strDN = strContainer.Add(xmlAttr.Value);
//                            break;
//                        case "newdn":
//                            attr.Add(new Attribute(xmlAttr.Value, strContainer));
//                            break;
//                    }
//                }

//                foreach (XmlNode childNode in deltaNode.ChildNodes)
//                {
//                    switch (childNode.Name)
//                    {
//                        case "attr":
//                            attr.Add(new Attribute(childNode, strContainer));
//                            break;
//                        case "dn-attr":
//                            attr.Add(new Attribute(childNode, strContainer));
//                            break;
//                    }
//                }

//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error occurred in Delta object constructor.", ex);
//            }
//        }

//        public operation Operation
//        {
//            get
//            {
//                return opOperation;
//            }
//        }
//        public string DN
//        {
//            get
//            {
//                return strContainer[strDN];
//            }
//        }
//        public List<Attribute> Attributes
//        {
//            get
//            {
//                return attr;
//            }
//        }
//        public List<string> AttributeNames
//        {
//            get
//            {
//                if (attr == null)
//                {
//                    return null;
//                }
//                else
//                {
//                    List<string> Names = new List<string>();
//                    foreach (Attribute bute in attr)
//                    {
//                        Names.Add(bute.Name);
//                    }
//                    return Names;
//                }
//            }
//        }

//        public Attribute AttributeByName(string AttributeName)
//        {
//            foreach (Attribute attrib in attr)
//            {
//                if (attrib.Name == AttributeName)
//                {
//                    return attrib;
//                }
//            }
//            return null;
//        }

//        public int AttribIndexByName(string AttributeName)
//        {
//            for (int i = 0; i < attr.Count; i++)
//            {
//                if (attr[i].Name == AttributeName)
//                {
//                    return i;
//                }
//            }
//            return -1;
//        }
//    }

//    class Entry
//    {
//        private int strDN;
//        private int strPrimaryObjectClass;
//        private string[] strObjectClass = new string[0];
//        private List<Attribute> attr = new List<Attribute>();
//        private csObject parent;
//        private StringContainer strContainer;

//        public Entry(XmlNode entryNode, csObject parentCSobject, StringContainer container)
//        {
//            try
//            {
//                if (parentCSobject != null)
//                {
//                    parent = parentCSobject;
//                }
//                strContainer = container;
//                if (entryNode.Attributes.GetNamedItem("dn") != null)
//                {
//                    strDN = strContainer.Add(entryNode.Attributes.GetNamedItem("dn").Value);
//                    attr.Add(new Attribute(strContainer[strDN], strContainer));
//                }
//                //Attribute tempAttribute = new Attribute();
//                foreach (XmlNode childNode in entryNode.ChildNodes)
//                {
//                    switch (childNode.Name)
//                    {
//                        case "primary-objectclass":
//                            strPrimaryObjectClass = strContainer.Add(childNode.InnerText);
//                            break;
//                        case "objectclass":
//                            strObjectClass = new string[entryNode.SelectNodes("oc-value").Count];
//                            int counter = 0;
//                            foreach (XmlNode ocVal in entryNode.SelectNodes("oc-value"))
//                            {
//                                strObjectClass[counter] = ocVal.InnerText;
//                                counter++;
//                            }
//                            break;
//                        case "attr":
//                            //tempAttribute = new Attribute(childNode);
//                            //attr.Add(tempAttribute);
//                            attr.Add(new Attribute(childNode, strContainer));
//                            break;
//                        case "dn-attr":
//                            //tempAttribute = new Attribute(childNode);
//                            //attr.Add(tempAttribute);
//                            attr.Add(new Attribute(childNode, strContainer));
//                            break;

//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error occurred in Entry object constructor.", ex);
//            }
//        }

//        public string DN
//        {
//            get
//            {
//                return strContainer[strDN];
//            }
//        }
//        public string PrimaryObjectClass
//        {
//            get
//            {
//                return strContainer[strPrimaryObjectClass];
//            }
//        }
//        public string[] ObjectClass
//        {
//            get
//            {
//                return strObjectClass;
//            }
//        }
//        public List<Attribute> Attributes
//        {
//            get
//            {
//                return attr;
//            }
//        }
//        public List<string> AttributeNames
//        {
//            get
//            {
//                if (attr == null)
//                {
//                    return null;
//                }
//                else
//                {
//                    List<string> Names = new List<string>();
//                    foreach (Attribute bute in attr)
//                    {
//                        Names.Add(bute.Name);
//                    }
//                    return Names;
//                }
//            }
//        }
//        public Attribute AttributeByName(string AttributeName)
//        {
//            foreach (Attribute attrib in attr)
//            {
//                if (attrib.Name == AttributeName)
//                {
//                    return attrib;
//                }
//            }
//            return null;
//        }
//        public int AttribIndexByName(string AttributeName)
//        {
//            for (int i = 0; i < attr.Count; i++)
//            {
//                if (attr[i].Name == AttributeName)
//                {
//                    return i;
//                }
//            }
//            return -1;
//        }
//        public csObject Parent
//        {
//            get
//            {
//                return parent;
//            }
//        }
//    }

//    class Attribute
//    {
//        private int strName;
//        private int strType;
//        private operation opOperation;
//        private bool bMultivalued;
//        private List<AttributeValue> vals = new List<AttributeValue>();
//        private bool bDNattr;
//        private StringContainer strContainer;


//        public Attribute(XmlNode attributeNode, StringContainer container)
//        {
//            try
//            {
//                strContainer = container;
//                foreach (XmlAttribute xmlAttr in attributeNode.Attributes)
//                {
//                    switch (xmlAttr.Name)
//                    {
//                        case "name":
//                            strName = strContainer.Add(xmlAttr.Value);
//                            break;
//                        case "type":
//                            strType = strContainer.Add(xmlAttr.Value);
//                            break;
//                        case "operation":
//                            switch (xmlAttr.Value)
//                            {
//                                case "delete-add":
//                                    opOperation = operation.deleteAdd;
//                                    break;
//                                case "add":
//                                    opOperation = operation.add;
//                                    break;
//                                case "replace":
//                                    opOperation = operation.replace;
//                                    break;
//                                case "update":
//                                    opOperation = operation.update;
//                                    break;
//                                case "delete":
//                                    opOperation = operation.delete;
//                                    break;
//                                case "none":
//                                    opOperation = operation.none;
//                                    break;
//                            }
//                            break;
//                        case "multivalued":
//                            bMultivalued = Convert.ToBoolean(xmlAttr.Value);
//                            break;
//                    }
//                }

//                switch (attributeNode.Name)
//                {
//                    case "attr":
//                        bDNattr = false;
//                        foreach (XmlNode childNode in attributeNode.ChildNodes)
//                        {
//                            if (childNode.Name == "value")
//                            {
//                                vals.Add(new AttributeValue(childNode, strContainer));
//                            }
//                        }
//                        break;
//                    case "dn-attr":
//                        bDNattr = true;
//                        foreach (XmlNode childNode in attributeNode.ChildNodes)
//                        {
//                            if (childNode.Name == "dn-value")
//                            {
//                                foreach (XmlNode subNode in childNode)
//                                {
//                                    if (subNode.Name == "dn")
//                                    {
//                                        vals.Add(new AttributeValue(subNode, strContainer));
//                                    }
//                                }
//                            }
//                        }
//                        break;
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error occurred in Attribute object constructor.", ex);
//            }
//        }
//        public Attribute() { }

//        //additional contructor created to support DN changes
//        //no XML to parse
//        public Attribute(string dnValue, StringContainer container)
//        {
//            strContainer = container;
//            strName = strContainer.Add("DN");
//            strType = strContainer.Add("DN");
//            opOperation = operation.update;
//            bMultivalued = false;
//            bDNattr = true;
//            vals.Add(new AttributeValue(dnValue, strContainer));
//        }

//        public string Name
//        {
//            get
//            {
//                return strContainer[strName];
//            }
//        }
//        public string Type
//        {
//            get
//            {
//                return strContainer[strType];
//            }
//        }
//        public operation Operation
//        {
//            get
//            {
//                return opOperation;
//            }
//        }
//        public bool Multivalued
//        {
//            get
//            {
//                return bMultivalued;
//            }
//        }
//        public List<AttributeValue> Values
//        {
//            get
//            {
//                return vals;
//            }
//        }
//        public List<string> StringValues
//        {
//            get
//            {
//                List<string> strValues = new List<string>(vals.Count);
//                if (vals.Count > 0)
//                {
//                    strValues = new List<string>(vals.Count);
//                    for (int i = 0; i < vals.Count; i++)
//                    {
//                        strValues.Add(vals[i].Value);
//                    }
//                }
//                else
//                {
//                    strValues.Add("");
//                }
//                return strValues;
//            }
//        }
//        public List<string> ADStringValues
//        {
//            get
//            {
//                List<string> strValues = new List<string>(vals.Count);
//                for (int i = 0; i < vals.Count; i++)
//                {
//                    strValues.Add(vals[i].ADvalue);
//                }
//                return strValues;
//            }
//        }
//        public bool isDN
//        {
//            get
//            {
//                return bDNattr;
//            }
//        }

//    }

//    class AttributeValue
//    {
//        private operation opOperation;
//        private int val;
//        private int ADval;
//        private StringContainer strContainer;

//        public AttributeValue(XmlNode valueNode, StringContainer container)
//        {
//            try
//            {
//                strContainer = container;
//                if (valueNode.InnerText != null)
//                {
//                    val = strContainer.Add(valueNode.InnerText);
//                }
//                else
//                {
//                    val = strContainer.Add("");
//                }
//                foreach (XmlAttribute xmlAttr in valueNode.Attributes)
//                {
//                    switch (xmlAttr.Name)
//                    {
//                        case "operation":
//                            switch (xmlAttr.Value)
//                            {
//                                case "delete-add":
//                                    opOperation = operation.deleteAdd;
//                                    break;
//                                case "add":
//                                    opOperation = operation.add;
//                                    break;
//                                case "replace":
//                                    opOperation = operation.replace;
//                                    break;
//                                case "update":
//                                    opOperation = operation.update;
//                                    break;
//                                case "delete":
//                                    opOperation = operation.delete;
//                                    break;
//                                case "none":
//                                    opOperation = operation.none;
//                                    break;
//                            }
//                            break;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Exception occurred in AttributeValue contructor", ex);
//            }
//        }

//        //additional contructor created to support DN changes
//        //no XML to parse
//        public AttributeValue(string value, StringContainer container)
//        {
//            strContainer = container;
//            val = strContainer.Add(value);
//            opOperation = operation.none;
//        }

//        public operation Operation
//        {
//            get
//            {
//                return opOperation;
//            }
//        }
//        public string Value
//        {
//            get
//            {
//                return strContainer[val];
//            }
//        }
//        public string ADvalue
//        {
//            get
//            {
//                return strContainer[ADval];
//            }
//            set
//            {
//                ADval = strContainer.Add(value);
//            }
//        }
//    }

//    class Sequencer
//    {
//        private int iCurrentBatchNumber;
//        private int iCurrentSequenceNumber;
//        private int iUnappliedBatchNumber;
//        private int iUnappliedSequenceNumber;
//        private int iOriginalBatchNumber;
//        private int iOriginalSequenceNumber;

//        public Sequencer(XmlNode sequencerNode)
//        {
//            try
//            {
//                foreach (XmlNode childNode in sequencerNode)
//                {
//                    switch (childNode.Name)
//                    {
//                        case "orginal":
//                            foreach (XmlNode subNode in childNode)
//                            {
//                                switch (subNode.Name)
//                                {
//                                    case "batch-number":
//                                        iOriginalBatchNumber = Convert.ToInt32(subNode.InnerText);
//                                        break;
//                                    case "sequence-number":
//                                        iOriginalSequenceNumber = Convert.ToInt32(subNode.InnerText);
//                                        break;
//                                }
//                            }
//                            break;
//                        case "current":
//                            foreach (XmlNode subNode in childNode)
//                            {
//                                switch (subNode.Name)
//                                {
//                                    case "batch-number":
//                                        iCurrentBatchNumber = Convert.ToInt32(subNode.InnerText);
//                                        break;
//                                    case "sequence-number":
//                                        iCurrentSequenceNumber = Convert.ToInt32(subNode.InnerText);
//                                        break;
//                                }
//                            }
//                            break;
//                        case "unapplied":
//                            foreach (XmlNode subNode in childNode)
//                            {
//                                switch (subNode.Name)
//                                {
//                                    case "batch-number":
//                                        iUnappliedBatchNumber = Convert.ToInt32(subNode.InnerText);
//                                        break;
//                                    case "sequence-number":
//                                        iUnappliedSequenceNumber = Convert.ToInt32(subNode.InnerText);
//                                        break;
//                                }
//                            }
//                            break;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Exception occurred in Sequencer contructor", ex);
//            }
//        }

//        public int CurrentBatchNumber
//        {
//            get
//            {
//                return iCurrentBatchNumber;
//            }
//        }
//        public int CurrentSequenceNumber
//        {
//            get
//            {
//                return iCurrentSequenceNumber;
//            }
//        }
//        public int UnappliedBatchNumber
//        {
//            get
//            {
//                return iUnappliedBatchNumber;
//            }
//        }
//        public int UnappliedSequenceNumber
//        {
//            get
//            {
//                return iUnappliedSequenceNumber;
//            }
//        }
//        public int OriginalBatchNumber
//        {
//            get
//            {
//                return iOriginalBatchNumber;
//            }
//        }
//        public int OriginalSequenceNumber
//        {
//            get
//            {
//                return iOriginalSequenceNumber;
//            }
//        }
//    }

//    class ExportError
//    {
//        private DateTime dateOccurred;
//        private DateTime firstOccurred;
//        private string retryCount;
//        private string errorType;
//        private string errorCode;
//        private string errorLiteral;
//        private string serverErrorDetail;

//        public ExportError(XmlNode exportErrorNode)
//        {
//            try
//            {
//                foreach (XmlAttribute attrib in exportErrorNode.Attributes)
//                {
//                    switch (attrib.Name)
//                    {
//                        case "first-occurred":
//                            firstOccurred = Convert.ToDateTime(attrib.InnerText);
//                            break;
//                        case "date-occurred":
//                            dateOccurred = Convert.ToDateTime(attrib.InnerText);
//                            break;
//                        case "retry-count":
//                            retryCount = attrib.InnerText;
//                            break;
//                        case "error-type":
//                            errorType = attrib.InnerText;
//                            break;
//                    }
//                }
//                foreach (XmlNode childNode in exportErrorNode)
//                {
//                    switch (childNode.Name)
//                    {
//                        case "export-status":
//                            foreach (XmlNode cNode in childNode)
//                            {
//                                if (cNode.Name == "cd-error")
//                                {
//                                    foreach (XmlNode ChildN in cNode)
//                                    {
//                                        switch (ChildN.Name)
//                                        {
//                                            case "error-literal":
//                                                errorLiteral = ChildN.InnerText;
//                                                break;
//                                            case "error-code":
//                                                errorCode = ChildN.InnerText;
//                                                break;
//                                            case "server-error-detail":
//                                                serverErrorDetail = ChildN.InnerText;
//                                                break;
//                                        }
//                                    }
//                                }
//                            }
//                            break;
//                        case "export-error":
//                            foreach (XmlAttribute attrib in exportErrorNode.Attributes)
//                            {
//                                switch (attrib.Name)
//                                {
//                                    case "first-occurred":
//                                        firstOccurred = Convert.ToDateTime(attrib.InnerText);
//                                        break;
//                                    case "date-occurred":
//                                        dateOccurred = Convert.ToDateTime(attrib.InnerText);
//                                        break;
//                                    case "retry-count":
//                                        retryCount = attrib.InnerText;
//                                        break;
//                                    case "error-type":
//                                        errorType = attrib.InnerText;
//                                        break;
//                                }
//                            }
//                            foreach (XmlNode cNode in childNode)
//                            {
//                                if (cNode.Name == "cd-error")
//                                {
//                                    foreach (XmlNode ChildN in cNode)
//                                    {
//                                        switch (ChildN.Name)
//                                        {
//                                            case "error-literal":
//                                                errorLiteral = ChildN.InnerText;
//                                                break;
//                                            case "error-code":
//                                                errorCode = ChildN.InnerText;
//                                                break;
//                                            case "server-error-detail":
//                                                serverErrorDetail = ChildN.InnerText;
//                                                break;
//                                        }
//                                    }
//                                }
//                            }
//                            break;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Exception occurred in ExportError constructor", ex);
//            }
//        }

//        public DateTime DateOccurred
//        {
//            get
//            {
//                return dateOccurred;
//            }
//        }
//        public DateTime FirstOccurred
//        {
//            get
//            {
//                return firstOccurred;
//            }
//        }
//        public string RetryCount
//        {
//            get
//            {
//                return retryCount;
//            }
//        }
//        public string ErrorType
//        {
//            get
//            {
//                return errorType;
//            }
//        }
//        public string ErrorCode
//        {
//            get
//            {
//                return errorCode;
//            }
//        }
//        public string ErrorLiteral
//        {
//            get
//            {
//                return errorLiteral;
//            }
//        }
//        public string ServerErrorDetail
//        {
//            get
//            {
//                return serverErrorDetail;
//            }
//        }
//    }
//}
