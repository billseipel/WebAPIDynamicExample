﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIDynamicExample.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebAPIDynamicExample.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;request&gt;
        ///	&lt;type_of_data&gt;Spending&lt;/type_of_data&gt;
        ///	&lt;records_from&gt;1&lt;/records_from&gt;
        ///	&lt;max_records&gt;1000&lt;/max_records&gt;
        ///	&lt;search_criteria&gt;
        ///		&lt;criteria&gt;
        ///			&lt;name&gt;spending_category&lt;/name&gt;
        ///			&lt;type&gt;value&lt;/type&gt;
        ///			&lt;value&gt;cc&lt;/value&gt;
        ///		&lt;/criteria&gt;
        ///		&lt;criteria&gt;
        ///			&lt;name&gt;mwbe_category&lt;/name&gt;
        ///			&lt;type&gt;value&lt;/type&gt;
        ///			&lt;value&gt;7&lt;/value&gt;
        ///		&lt;/criteria&gt;
        ///		&lt;criteria&gt;
        ///			&lt;name&gt;industry&lt;/name&gt;
        ///			&lt;type&gt;value&lt;/type&gt;
        ///			&lt;value&gt;2&lt;/value&gt;
        ///		&lt;/criteria&gt;
        ///		&lt;criteria&gt;
        ///			&lt;name&gt;fiscal_year&lt;/name&gt;
        ///			&lt;type&gt;value&lt;/typ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NYC_Spending_2018 {
            get {
                return ResourceManager.GetString("NYC_Spending_2018", resourceCulture);
            }
        }
    }
}
