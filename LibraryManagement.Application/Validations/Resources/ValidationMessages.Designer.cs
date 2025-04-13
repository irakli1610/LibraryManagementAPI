﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement.Application.Validations.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ValidationMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ValidationMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LibraryManagement.Application.Validations.Resources.ValidationMessages", typeof(ValidationMessages).Assembly);
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
        ///   Looks up a localized string similar to Author id can not be empty.
        /// </summary>
        internal static string AuthorIdNotNull {
            get {
                return ResourceManager.GetString("AuthorIdNotNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Biography can not be empty or null.
        /// </summary>
        internal static string BiographyEmpty {
            get {
                return ResourceManager.GetString("BiographyEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Book is can not be empty.
        /// </summary>
        internal static string BookIdEmpty {
            get {
                return ResourceManager.GetString("BookIdEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Borrow date can not be empty.
        /// </summary>
        internal static string BorrowDateEmpty {
            get {
                return ResourceManager.GetString("BorrowDateEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Borrow date must be less than or equal to current date.
        /// </summary>
        internal static string BorrowDateFromFuture {
            get {
                return ResourceManager.GetString("BorrowDateFromFuture", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Date of birth must be less than or equal to current date.
        /// </summary>
        internal static string DateOfBirthNotFromFuture {
            get {
                return ResourceManager.GetString("DateOfBirthNotFromFuture", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Descriptioncan not be null or empty.
        /// </summary>
        internal static string DescriptionEmpty {
            get {
                return ResourceManager.GetString("DescriptionEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Due date can not be empty.
        /// </summary>
        internal static string DueDateEmpty {
            get {
                return ResourceManager.GetString("DueDateEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Due date must be greather than Borrow date.
        /// </summary>
        internal static string DueDateMustBeAfterBorrowDate {
            get {
                return ResourceManager.GetString("DueDateMustBeAfterBorrowDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email can not be empty.
        /// </summary>
        internal static string EmailEmpty {
            get {
                return ResourceManager.GetString("EmailEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Email.
        /// </summary>
        internal static string EmailInvalid {
            get {
                return ResourceManager.GetString("EmailInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to First name can not be empty or null.
        /// </summary>
        internal static string FirstNameEmpty {
            get {
                return ResourceManager.GetString("FirstNameEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to First name should not exceed 50 characters.
        /// </summary>
        internal static string FirstNameLength {
            get {
                return ResourceManager.GetString("FirstNameLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to URL is not valid.
        /// </summary>
        internal static string InvalidUrl {
            get {
                return ResourceManager.GetString("InvalidUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ISBN can not be empty.
        /// </summary>
        internal static string ISBNEmpty {
            get {
                return ResourceManager.GetString("ISBNEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ISBN must be exactly 13 characters.
        /// </summary>
        internal static string ISBNLength {
            get {
                return ResourceManager.GetString("ISBNLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ISBN field must be numerical characters.
        /// </summary>
        internal static string ISBNMustBeNumbers {
            get {
                return ResourceManager.GetString("ISBNMustBeNumbers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Last name can not be empty or null.
        /// </summary>
        internal static string LastNameEmpty {
            get {
                return ResourceManager.GetString("LastNameEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Last name should not exceed 50 characters.
        /// </summary>
        internal static string LastNameLength {
            get {
                return ResourceManager.GetString("LastNameLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Membership date must be less than or equal to current date.
        /// </summary>
        internal static string MembershipDateNotFromFuture {
            get {
                return ResourceManager.GetString("MembershipDateNotFromFuture", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Patron id can not be empty.
        /// </summary>
        internal static string PatronIdEmpty {
            get {
                return ResourceManager.GetString("PatronIdEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Publication year must be less than or equal current year.
        /// </summary>
        internal static string PublicationYearNotFromFuture {
            get {
                return ResourceManager.GetString("PublicationYearNotFromFuture", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to quantity must be positive number.
        /// </summary>
        internal static string QuantityMustBePositive {
            get {
                return ResourceManager.GetString("QuantityMustBePositive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Return date can not be before borrow date.
        /// </summary>
        internal static string ReturnDateBeforeBorrowDate {
            get {
                return ResourceManager.GetString("ReturnDateBeforeBorrowDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Title can not be empty.
        /// </summary>
        internal static string TitleEmpty {
            get {
                return ResourceManager.GetString("TitleEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Title should not exceed 50 characters.
        /// </summary>
        internal static string TitleLength {
            get {
                return ResourceManager.GetString("TitleLength", resourceCulture);
            }
        }
    }
}
