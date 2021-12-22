using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace WebAPIDynamicExample.Util
{
    public static class XmlBuilder
    {
        public static string LoadSpendingXML(string year)
        {
            XmlDocument xmldoc = new XmlDocument();
            //xmldoc.LoadXml(Resources.NYC_Spending_2018);
            xmldoc.LoadXml(@$"<request>
								<type_of_data>Spending</type_of_data>
								<records_from>1</records_from>
								<max_records>1000</max_records>
								<search_criteria>
								<criteria>
									<name>spending_category</name>
									<type>value</type>
									<value>cc</value>
								</criteria>
								<criteria>
									<name>mwbe_category</name>
									<type>value</type>
									<value>7</value>
								</criteria>
								<criteria>
									<name>industry</name>
									<type>value</type>
									<value>2</value>
								</criteria>
								<criteria>
									<name>fiscal_year</name>
									<type>value</type>
									<value>{year}</value>
								</criteria>
							</search_criteria>
							<response_columns>
								<column>agency</column>
								<column>fiscal_year</column>
								<column>document_id</column>
								<column>payee_name</column>
								<column>department</column>
								<column>check_amount</column>
								<column>expense_category</column>
								<column>contract_id</column>
								<column>capital_project</column>
								<column>industry</column>
								<column>issue_date</column>
								<column>spending_category</column>
								<column>mwbe_category</column>
								<column>sub_vendor</column>
								<column>associated_prime_vendor</column>
								<column>sub_contract_reference_id</column>
								<column>woman_owned_business</column>
								<column>emerging_business</column>
								<column>budget_code</column>
							</response_columns>
							</request>");
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmldoc.WriteTo(xw);
            return sw.ToString();
        }
    }
}
