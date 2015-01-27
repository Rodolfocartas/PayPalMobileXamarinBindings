using System;
using System.Drawing;

using ObjCRuntime;
using Foundation;
using UIKit;

using AudioToolbox;
using AVFoundation;
using CoreLocation;
using CoreMedia;
using MessageUI;
using MobileCoreServices;
using SystemConfiguration;

namespace PayPalMobileXamarinBindings
{

	// @interface PayPalConfiguration : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	interface PayPalConfiguration : INSCopying {

		// @property (readwrite, copy, nonatomic) NSString * defaultUserEmail;
		[Export ("defaultUserEmail")]
		string DefaultUserEmail { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * defaultUserPhoneCountryCode;
		[Export ("defaultUserPhoneCountryCode")]
		string DefaultUserPhoneCountryCode { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * defaultUserPhoneNumber;
		[Export ("defaultUserPhoneNumber")]
		string DefaultUserPhoneNumber { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * merchantName;
		[Export ("merchantName")]
		string MerchantName { get; set; }

		// @property (readwrite, copy, nonatomic) NSURL * merchantPrivacyPolicyURL;
		[Export ("merchantPrivacyPolicyURL", ArgumentSemantic.Copy)]
		NSUrl MerchantPrivacyPolicyURL { get; set; }

		// @property (readwrite, copy, nonatomic) NSURL * merchantUserAgreementURL;
		[Export ("merchantUserAgreementURL", ArgumentSemantic.Copy)]
		NSUrl MerchantUserAgreementURL { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL acceptCreditCards;
		[Export ("acceptCreditCards", ArgumentSemantic.UnsafeUnretained)]
		bool AcceptCreditCards { get; set; }

		// @property (assign, readwrite, nonatomic) PayPalShippingAddressOption payPalShippingAddressOption;
		[Export ("payPalShippingAddressOption", ArgumentSemantic.UnsafeUnretained)]
		PayPalShippingAddressOption PayPalShippingAddressOption { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL rememberUser;
		[Export ("rememberUser", ArgumentSemantic.UnsafeUnretained)]
		bool RememberUser { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * languageOrLocale;
		[Export ("languageOrLocale")]
		string LanguageOrLocale { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL disableBlurWhenBackgrounding;
		[Export ("disableBlurWhenBackgrounding", ArgumentSemantic.UnsafeUnretained)]
		bool DisableBlurWhenBackgrounding { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL presentingInPopover;
		[Export ("presentingInPopover", ArgumentSemantic.UnsafeUnretained)]
		bool PresentingInPopover { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL forceDefaultsInSandbox;
		[Export ("forceDefaultsInSandbox", ArgumentSemantic.UnsafeUnretained)]
		bool ForceDefaultsInSandbox { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * sandboxUserPassword;
		[Export ("sandboxUserPassword")]
		string SandboxUserPassword { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * sandboxUserPin;
		[Export ("sandboxUserPin")]
		string SandboxUserPin { get; set; }
	}

	// @protocol PayPalFuturePaymentDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PayPalFuturePaymentDelegate {

		// @required -(void)payPalFuturePaymentDidCancel:(PayPalFuturePaymentViewController *)futurePaymentViewController;
		[Export ("payPalFuturePaymentDidCancel:")]
		[Abstract]
		void PayPalFuturePaymentDidCancel (PayPalFuturePaymentViewController futurePaymentViewController);

		// @required -(void)payPalFuturePaymentViewController:(PayPalFuturePaymentViewController *)futurePaymentViewController didAuthorizeFuturePayment:(NSDictionary *)futurePaymentAuthorization;
		[Export ("payPalFuturePaymentViewController:didAuthorizeFuturePayment:")]
		[Abstract]
		void DidAuthorizeFuturePayment (PayPalFuturePaymentViewController futurePaymentViewController, NSDictionary futurePaymentAuthorization);

		// @optional -(void)payPalFuturePaymentViewController:(PayPalFuturePaymentViewController *)futurePaymentViewController willAuthorizeFuturePayment:(NSDictionary *)futurePaymentAuthorization completionBlock:(PayPalFuturePaymentDelegateCompletionBlock)completionBlock;
		[Export ("payPalFuturePaymentViewController:willAuthorizeFuturePayment:completionBlock:")]
		void WillAuthorizeFuturePayment (PayPalFuturePaymentViewController futurePaymentViewController, NSDictionary futurePaymentAuthorization, Action completionBlock);
	}

	// @interface PayPalFuturePaymentViewController : UINavigationController
	[BaseType (typeof (UINavigationController))]
	interface PayPalFuturePaymentViewController {

		// -(instancetype)initWithConfiguration:(PayPalConfiguration *)configuration delegate:(id<PayPalFuturePaymentDelegate>)delegate;
		[Export ("initWithConfiguration:delegate:")]
		IntPtr Constructor (PayPalConfiguration configuration, PayPalFuturePaymentDelegate payPalFuturePaymentDelegate);

		// @property (readonly, nonatomic, weak) id<PayPalFuturePaymentDelegate> futurePaymentDelegate;
		[Export ("futurePaymentDelegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakFuturePaymentDelegate { get; }

		// @property (readonly, nonatomic, weak) id<PayPalFuturePaymentDelegate> futurePaymentDelegate;
		[Wrap ("WeakFuturePaymentDelegate")]
		PayPalFuturePaymentDelegate FuturePaymentDelegate { get; }
	}

	// @interface PayPalPaymentDetails : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	interface PayPalPaymentDetails : INSCopying {

		// @property (readwrite, copy, nonatomic) NSDecimalNumber * subtotal;
		[Export ("subtotal", ArgumentSemantic.Copy)]
		NSDecimalNumber Subtotal { get; set; }

		// @property (readwrite, copy, nonatomic) NSDecimalNumber * shipping;
		[Export ("shipping", ArgumentSemantic.Copy)]
		NSDecimalNumber Shipping { get; set; }

		// @property (readwrite, copy, nonatomic) NSDecimalNumber * tax;
		[Export ("tax", ArgumentSemantic.Copy)]
		NSDecimalNumber Tax { get; set; }

		// +(PayPalPaymentDetails *)paymentDetailsWithSubtotal:(NSDecimalNumber *)subtotal withShipping:(NSDecimalNumber *)shipping withTax:(NSDecimalNumber *)tax;
		[Static, Export ("paymentDetailsWithSubtotal:withShipping:withTax:")]
		PayPalPaymentDetails PaymentDetailsWithSubtotal (NSDecimalNumber subtotal, NSDecimalNumber shipping, NSDecimalNumber tax);
	}

	// @interface PayPalItem : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	interface PayPalItem : INSCopying {

		// @property (readwrite, copy, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; set; }

		// @property (assign, readwrite, nonatomic) NSUInteger quantity;
		[Export ("quantity", ArgumentSemantic.UnsafeUnretained)]
		nuint Quantity { get; set; }

		// @property (readwrite, copy, nonatomic) NSDecimalNumber * price;
		[Export ("price", ArgumentSemantic.Copy)]
		NSDecimalNumber Price { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * currency;
		[Export ("currency")]
		string Currency { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * sku;
		[Export ("sku")]
		string Sku { get; set; }

		// +(PayPalItem *)itemWithName:(NSString *)name withQuantity:(NSUInteger)quantity withPrice:(NSDecimalNumber *)price withCurrency:(NSString *)currency withSku:(NSString *)sku;
		[Static, Export ("itemWithName:withQuantity:withPrice:withCurrency:withSku:")]
		PayPalItem ItemWithName (string name, nuint quantity, NSDecimalNumber price, string currency, string sku);

		// +(NSDecimalNumber *)totalPriceForItems:(NSArray *)items;
		[Static, Export ("totalPriceForItems:")]
		NSDecimalNumber TotalPriceForItems (NSObject [] items);
	}

	// @interface PayPalShippingAddress : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	interface PayPalShippingAddress : INSCopying {

		// @property (readwrite, copy, nonatomic) NSString * recipientName;
		[Export ("recipientName")]
		string RecipientName { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * line1;
		[Export ("line1")]
		string Line1 { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * line2;
		[Export ("line2")]
		string Line2 { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * city;
		[Export ("city")]
		string City { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * state;
		[Export ("state")]
		string State { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * postalCode;
		[Export ("postalCode")]
		string PostalCode { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * countryCode;
		[Export ("countryCode")]
		string CountryCode { get; set; }

		// +(PayPalShippingAddress *)shippingAddressWithRecipientName:(NSString *)recipientName withLine1:(NSString *)line1 withLine2:(NSString *)line2 withCity:(NSString *)city withState:(NSString *)state withPostalCode:(NSString *)postalCode withCountryCode:(NSString *)countryCode;
		[Static, Export ("shippingAddressWithRecipientName:withLine1:withLine2:withCity:withState:withPostalCode:withCountryCode:")]
		PayPalShippingAddress ShippingAddressWithRecipientName (string recipientName, string line1, string line2, string city, string state, string postalCode, string countryCode);
	}

	// @interface PayPalPayment : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	interface PayPalPayment : INSCopying {

		// @property (readwrite, copy, nonatomic) NSString * currencyCode;
		[Export ("currencyCode")]
		string CurrencyCode { get; set; }

		// @property (readwrite, copy, nonatomic) NSDecimalNumber * amount;
		[Export ("amount", ArgumentSemantic.Copy)]
		NSDecimalNumber Amount { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * shortDescription;
		[Export ("shortDescription")]
		string ShortDescription { get; set; }

		// @property (assign, readwrite, nonatomic) PayPalPaymentIntent intent;
		[Export ("intent", ArgumentSemantic.UnsafeUnretained)]
		PayPalPaymentIntent Intent { get; set; }

		// @property (readwrite, copy, nonatomic) PayPalPaymentDetails * paymentDetails;
		[Export ("paymentDetails", ArgumentSemantic.Copy)]
		PayPalPaymentDetails PaymentDetails { get; set; }

		// @property (readwrite, copy, nonatomic) NSArray * items;
		[Export ("items", ArgumentSemantic.Copy)]
		NSObject [] Items { get; set; }

		// @property (readwrite, copy, nonatomic) PayPalShippingAddress * shippingAddress;
		[Export ("shippingAddress", ArgumentSemantic.Copy)]
		PayPalShippingAddress ShippingAddress { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * invoiceNumber;
		[Export ("invoiceNumber")]
		string InvoiceNumber { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * custom;
		[Export ("custom")]
		string Custom { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * softDescriptor;
		[Export ("softDescriptor")]
		string SoftDescriptor { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * bnCode;
		[Export ("bnCode")]
		string BnCode { get; set; }

		// @property (readonly, assign, nonatomic) BOOL processable;
		[Export ("processable", ArgumentSemantic.UnsafeUnretained)]
		bool Processable { get; }

		// @property (readonly, copy, nonatomic) NSString * localizedAmountForDisplay;
		[Export ("localizedAmountForDisplay")]
		string LocalizedAmountForDisplay { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * confirmation;
		[Export ("confirmation", ArgumentSemantic.Copy)]
		NSDictionary Confirmation { get; }

		// +(PayPalPayment *)paymentWithAmount:(NSDecimalNumber *)amount currencyCode:(NSString *)currencyCode shortDescription:(NSString *)shortDescription intent:(PayPalPaymentIntent)intent;
		[Static, Export ("paymentWithAmount:currencyCode:shortDescription:intent:")]
		PayPalPayment PaymentWithAmount (NSDecimalNumber amount, string currencyCode, string shortDescription, PayPalPaymentIntent intent);
	}

	// @protocol PayPalPaymentDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PayPalPaymentDelegate {

		// @required -(void)payPalPaymentDidCancel:(PayPalPaymentViewController *)paymentViewController;
		[Export ("payPalPaymentDidCancel:")]
		[Abstract]
		void PayPalPaymentDidCancel (PayPalPaymentViewController paymentViewController);

		// @required -(void)payPalPaymentViewController:(PayPalPaymentViewController *)paymentViewController didCompletePayment:(PayPalPayment *)completedPayment;
		[Export ("payPalPaymentViewController:didCompletePayment:")]
		[Abstract]
		void DidCompletePayment (PayPalPaymentViewController paymentViewController, PayPalPayment completedPayment);

		// @optional -(void)payPalPaymentViewController:(PayPalPaymentViewController *)paymentViewController willCompletePayment:(PayPalPayment *)completedPayment completionBlock:(PayPalPaymentDelegateCompletionBlock)completionBlock;
		[Export ("payPalPaymentViewController:willCompletePayment:completionBlock:")]
		void WillCompletePayment (PayPalPaymentViewController paymentViewController, PayPalPayment completedPayment, Action completionBlock);
	}

	// @interface PayPalPaymentViewController : UINavigationController
	[BaseType (typeof (UINavigationController))]
	interface PayPalPaymentViewController {

		// -(instancetype)initWithPayment:(PayPalPayment *)payment configuration:(PayPalConfiguration *)configuration delegate:(id<PayPalPaymentDelegate>)delegate;
		[Export ("initWithPayment:configuration:delegate:")]
		IntPtr Constructor (PayPalPayment payment, PayPalConfiguration configuration, PayPalPaymentDelegate payPalPaymentDelegate);

		// @property (readonly, nonatomic, weak) id<PayPalPaymentDelegate> paymentDelegate;
		[Export ("paymentDelegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakPaymentDelegate { get; }

		// @property (readonly, nonatomic, weak) id<PayPalPaymentDelegate> paymentDelegate;
		[Wrap ("WeakPaymentDelegate")]
		PayPalPaymentDelegate PaymentDelegate { get; }

		// @property (readonly, assign, nonatomic) PayPalPaymentViewControllerState state;
		[Export ("state", ArgumentSemantic.UnsafeUnretained)]
		PayPalPaymentViewControllerState State { get; }
	}

	// @protocol PayPalProfileSharingDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PayPalProfileSharingDelegate {

		// @required -(void)userDidCancelPayPalProfileSharingViewController:(PayPalProfileSharingViewController *)profileSharingViewController;
		[Export ("userDidCancelPayPalProfileSharingViewController:")]
		[Abstract]
		void UserDidCancelPayPalProfileSharingViewController (PayPalProfileSharingViewController profileSharingViewController);

		// @required -(void)payPalProfileSharingViewController:(PayPalProfileSharingViewController *)profileSharingViewController userDidLogInWithAuthorization:(NSDictionary *)profileSharingAuthorization;
		[Export ("payPalProfileSharingViewController:userDidLogInWithAuthorization:")]
		[Abstract]
		void UserDidLogInWithAuthorization (PayPalProfileSharingViewController profileSharingViewController, NSDictionary profileSharingAuthorization);

		// @optional -(void)payPalProfileSharingViewController:(PayPalProfileSharingViewController *)profileSharingViewController userWillLogInWithAuthorization:(NSDictionary *)profileSharingAuthorization completionBlock:(PayPalProfileSharingDelegateCompletionBlock)completionBlock;
		[Export ("payPalProfileSharingViewController:userWillLogInWithAuthorization:completionBlock:")]
		void UserWillLogInWithAuthorization (PayPalProfileSharingViewController profileSharingViewController, NSDictionary profileSharingAuthorization, Action completionBlock);
	}

	// @interface PayPalProfileSharingViewController : UINavigationController
	[BaseType (typeof (UINavigationController))]
	interface PayPalProfileSharingViewController {

		// -(instancetype)initWithScopeValues:(NSSet *)scopeValues configuration:(PayPalConfiguration *)configuration delegate:(id<PayPalProfileSharingDelegate>)delegate;
		[Export ("initWithScopeValues:configuration:delegate:")]
		IntPtr Constructor (NSSet scopeValues, PayPalConfiguration configuration, PayPalProfileSharingDelegate payPalProfileSharingDelegate);

		// @property (readonly, nonatomic, weak) id<PayPalProfileSharingDelegate> profileSharingDelegate;
		[Export ("profileSharingDelegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakProfileSharingDelegate { get; }

		// @property (readonly, nonatomic, weak) id<PayPalProfileSharingDelegate> profileSharingDelegate;
		[Wrap ("WeakProfileSharingDelegate")]
		PayPalProfileSharingDelegate ProfileSharingDelegate { get; }
	}

	// @interface PayPalMobile : NSObject
	[BaseType (typeof (NSObject))]
	interface PayPalMobile {

		// +(void)initializeWithClientIdsForEnvironments:(NSDictionary *)clientIdsForEnvironments;
		[Static, Export ("initializeWithClientIdsForEnvironments:")]
		void InitializeWithClientIdsForEnvironments (NSDictionary clientIdsForEnvironments);

		// +(void)preconnectWithEnvironment:(NSString *)environment;
		[Static, Export ("preconnectWithEnvironment:")]
		void PreconnectWithEnvironment (string environment);

		// +(NSString *)clientMetadataID;
		[Static, Export ("clientMetadataID")]
		string ClientMetadataID ();

		// +(NSString *)applicationCorrelationIDForEnvironment:(NSString *)environment;
		//[Availability (Deprecated = Platform.iOS | Platform.Mac)]
		[Static, Export ("applicationCorrelationIDForEnvironment:")]
		string ApplicationCorrelationIDForEnvironment (string environment);

		// +(void)clearAllUserData;
		[Static, Export ("clearAllUserData")]
		void ClearAllUserData ();

		// +(NSString *)libraryVersion;
		[Static, Export ("libraryVersion")]
		string LibraryVersion ();
	}

	[BaseType(typeof(NSObject))]
	public partial interface PayPalFields
	{
		[Field ("PayPalEnvironmentProduction", "__Internal")]
		NSString PayPalEnvironmentProduction { get; }

		[Field ("PayPalEnvironmentSandbox", "__Internal")]
		NSString PayPalEnvironmentSandbox { get; }

		[Field ("PayPalEnvironmentNoNetwork", "__Internal")]
		NSString PayPalEnvironmentNoNetwork { get; }
	}
}

