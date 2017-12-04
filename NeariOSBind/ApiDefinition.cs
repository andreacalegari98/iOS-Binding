using System;
using CoreBluetooth;
using CoreLocation;
using Foundation;
using ObjCRuntime;

namespace NearIT
{
    // @interface NITManager : NSObject
    [BaseType(typeof(NSObject))]
    interface NITManager
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        NITManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<NITManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic) BOOL showBackgroundNotification;
        [Export("showBackgroundNotification")]
        bool ShowBackgroundNotification { get; set; }

        // @property (nonatomic) BOOL showForegroundNotification;
        [Export("showForegroundNotification")]
        bool ShowForegroundNotification { get; set; }

        // +(void)setupWithApiKey:(NSString * _Nonnull)apiKey;
        [Static]
        [Export("setupWithApiKey:")]
        void SetupWithApiKey(string apiKey);

        // +(NITManager * _Nonnull)defaultManager;
        [Static]
        [Export("defaultManager")]
        NITManager DefaultManager { get; }

        // -(void)start;
        [Export("start")]
        void Start();

        // -(void)stop;
        [Export("stop")]
        void Stop();

        // -(void)refreshConfigWithCompletionHandler:(void (^ _Nullable)(NSError * _Nullable))completionHandler;
        [Export("refreshConfigWithCompletionHandler:")]
        void RefreshConfigWithCompletionHandler([NullAllowed] Action<NSError> completionHandler);

        // -(void)setDeviceTokenWithData:(NSData * _Nonnull)token;
        [Export("setDeviceTokenWithData:")]
        void SetDeviceTokenWithData(NSData token);

        // -(void)sendTrackingWithTrackingInfo:(NITTrackingInfo * _Nullable)trackingInfo event:(NSString * _Nullable)event;
        [Export("sendTrackingWithTrackingInfo:event:")]
        void SendTrackingWithTrackingInfo([NullAllowed] NITTrackingInfo trackingInfo, [NullAllowed] string @event);

        // -(void)setDeferredUserDataWithKey:(NSString * _Nonnull)key value:(NSString * _Nonnull)value;
        [Export("setDeferredUserDataWithKey:value:")]
        void SetUserData(string key, string value);

        // -(void)sendEventWithEvent:(NITEvent * _Nonnull)event completionHandler:(void (^ _Nullable)(NSError * _Nullable))handler;
        [Export("sendEventWithEvent:completionHandler:")]
        void SendEventWithEvent(NITEvent @event, [NullAllowed] Action<NSError> handler);

        // -(BOOL)processRecipeWithUserInfo:(NSDictionary<NSString *,id> * _Nonnull)userInfo completion:(void (^ _Nullable)(NITReactionBundle * _Nullable, NITTrackingInfo * _Nullable, NSError * _Nullable))completionHandler;
        [Export("processRecipeWithUserInfo:completion:")]
        bool ProcessRecipeWithUserInfo(NSDictionary<NSString, NSObject> userInfo, [NullAllowed] Action<NITReactionBundle, NITTrackingInfo, NSError> completionHandler);

        // -(void)couponsWithCompletionHandler:(void (^ _Nullable)(NSArray<NITCoupon *> * _Nullable, NSError * _Nullable))handler;
        [Export("couponsWithCompletionHandler:")]
        void CouponsWithCompletionHandler([NullAllowed] Action<NSArray<NITCoupon>, NSError> handler);

        //- (void) profileIdWithCompletionHandler:(void (^_Nonnull)(NSString* _Nullable profileId, NSError* _Nullable error))handler;
        [Export("profileIdWithCompletionHandler:")]
        void ProfileIdWithCompletionHandler(Action<NSString, NSError> handler);

        //- (void)resetProfileWithCompletionHandler:(void (^_Nonnull)(NSString* _Nullable profileId, NSError* _Nullable error))handler;
        [Export("resetProfileWithCompletionHandler:")]
        void ResetProfileWithCompletionHandler(Action<NSString, NSError> handler);

        //- (void)optOutWithCompletionHandler:(void (^_Nonnull)(BOOL success))handler;
        [Export("optOutWithCompletionHandler:")]
        void OptOutWithCompletionHandler(Action<bool> handler);

    }

    // @protocol NITManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NITManagerDelegate
    {
        // @required -(void)manager:(NITManager * _Nonnull)manager eventWithContent:(id _Nonnull)content trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo;
        [Abstract]
        [Export("manager:eventWithContent:trackingInfo:")]
        void EventWithContent(NITManager manager, NSObject content, NITTrackingInfo trackingInfo);

        // @required -(void)manager:(NITManager * _Nonnull)manager eventFailureWithError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("manager:eventFailureWithError:")]
        void EventFailureWithError(NITManager manager, NSError error);

        // @optional -(void)manager:(NITManager * _Nonnull)manager alertWantsToShowContent:(id _Nonnull)content;
        [Export("manager:alertWantsToShowContent:")]
        void AlertWantsToShowContent(NITManager manager, NSObject content);
    }

    // @interface NITContent : NITReactionBundle <NSCoding>
    [BaseType(typeof(NITReactionBundle))]
    interface NITContent : INSCoding
    {
        // @property (nonatomic, strong) NSArray<NITImage *> * _Nullable images __attribute__((deprecated("You should use 'image' attribute"))) __attribute__((deprecated("")));
        [NullAllowed, Export("images", ArgumentSemantic.Strong)]
        NITImage[] Images { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable videoLink __attribute__((deprecated("Unused"))) __attribute__((deprecated("")));
        [NullAllowed, Export("videoLink", ArgumentSemantic.Strong)]
        string VideoLink { get; set; }

        // @property (nonatomic, strong) NITAudio * _Nullable audio __attribute__((deprecated("Unused"))) __attribute__((deprecated("")));
        [NullAllowed, Export("audio", ArgumentSemantic.Strong)]
        NITAudio Audio { get; set; }

        // @property (nonatomic, strong) NITUpload * _Nullable upload __attribute__((deprecated("Unused"))) __attribute__((deprecated("")));
        [NullAllowed, Export("upload", ArgumentSemantic.Strong)]
        NITUpload Upload { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable title;
        [NullAllowed, Export("title", ArgumentSemantic.Strong)]
        string Title { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable content;
        [NullAllowed, Export("content", ArgumentSemantic.Strong)]
        string Content { get; set; }

        // @property (readonly, nonatomic) NITImage * _Nullable image;
        [NullAllowed, Export("image")]
        NITImage Image { get; }

        // @property (readonly, nonatomic) NITContentLink * _Nullable link;
        [NullAllowed, Export("link")]
        NITContentLink Link { get; }
    }

    // @interface NITImage : NITResource <NSCoding>
    [BaseType(typeof(NITResource))]
    interface NITImage : INSCoding
    {
        // @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable image;
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> Image { get; set; }

        // -(NSURL * _Nullable)smallSizeURL;
        [NullAllowed, Export("smallSizeURL")]

        NSUrl SmallSizeURL { get; }

        // -(NSURL * _Nullable)url;
        [NullAllowed, Export("url")]

        NSUrl Url { get; }
    }

    // @interface NITResource : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface NITResource : INSCoding
    {
        // @property (nonatomic, strong) NITJSONAPIResource * _Nullable resourceObject;
        [NullAllowed, Export("resourceObject", ArgumentSemantic.Strong)]
        NITJSONAPIResource ResourceObject { get; set; }
        // -(NSDictionary * _Nonnull)attributesMap;
        [Export("attributesMap")]

        NSDictionary AttributesMap { get; }

        // -(NSString * _Nullable)ID;
        // -(void)setID:(NSString * _Nonnull)ID;
        [NullAllowed, Export("ID")]

        string ID { get; set; }
    }

    // @interface NITAudio : NITResource <NSCoding>
    [BaseType(typeof(NITResource))]
    interface NITAudio : INSCoding
    {
        // @property (nonatomic, strong) NSDictionary<NSString *,NSString *> * _Nonnull audio;
        [Export("audio", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSString> Audio { get; set; }

        // -(NSURL * _Nullable)url;
        [NullAllowed, Export("url")]

        NSUrl Url { get; }
    }

    // @interface NITRecipe : NITResource <NSCoding>
    [BaseType(typeof(NITResource))]
    interface NITRecipe : INSCoding
    {
        // @property (nonatomic, strong) NSString * _Nullable name;
        [NullAllowed, Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable notification;
        [NullAllowed, Export("notification", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> Notification { get; set; }

        // @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable labels;
        [NullAllowed, Export("labels", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> Labels { get; set; }

        // @property (nonatomic, strong) NSArray<NSDictionary<NSString *,id> *> * _Nullable scheduling;
        [NullAllowed, Export("scheduling", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject>[] Scheduling { get; set; }

        // @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable cooldown;
        [NullAllowed, Export("cooldown", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> Cooldown { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull pulsePluginId;
        [Export("pulsePluginId", ArgumentSemantic.Strong)]
        string PulsePluginId { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull reactionPluginId;
        [Export("reactionPluginId", ArgumentSemantic.Strong)]
        string ReactionPluginId { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull reactionBundleId;
        [Export("reactionBundleId", ArgumentSemantic.Strong)]
        string ReactionBundleId { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable tags;
        [NullAllowed, Export("tags", ArgumentSemantic.Strong)]
        string[] Tags { get; set; }

        // @property (nonatomic, strong) NITResource * _Nonnull pulseBundle;
        [Export("pulseBundle", ArgumentSemantic.Strong)]
        NITResource PulseBundle { get; set; }

        // @property (nonatomic, strong) NITResource * _Nonnull pulseAction;
        [Export("pulseAction", ArgumentSemantic.Strong)]
        NITResource PulseAction { get; set; }

        // @property (nonatomic, strong) NITResource * _Nonnull reactionAction;
        [Export("reactionAction", ArgumentSemantic.Strong)]
        NITResource ReactionAction { get; set; }

        // @property (nonatomic, strong) NITResource * _Nonnull reactionBundle;
        [Export("reactionBundle", ArgumentSemantic.Strong)]
        NITResource ReactionBundle { get; set; }

        // -(BOOL)isEvaluatedOnline;
        [Export("isEvaluatedOnline")]

        bool IsEvaluatedOnline { get; }

        // -(BOOL)isForeground;
        [Export("isForeground")]

        bool IsForeground { get; }

        // -(NSString * _Nullable)notificationTitle;
        [NullAllowed, Export("notificationTitle")]

        string NotificationTitle { get; }

        // -(NSString * _Nullable)notificationBody;
        [NullAllowed, Export("notificationBody")]

        string NotificationBody { get; }
    }

    // @interface NITCoupon : NITReactionBundle <NSCoding>
    [BaseType(typeof(NITReactionBundle))]
    interface NITCoupon : INSCoding
    {
        // @property (nonatomic, strong) NSString * couponDescription;
        [Export("couponDescription", ArgumentSemantic.Strong)]
        string CouponDescription { get; set; }

        // @property (nonatomic, strong) NSString * value;
        [Export("value", ArgumentSemantic.Strong)]
        string Value { get; set; }

        // @property (nonatomic, strong) NSString * expiresAt;
        [Export("expiresAt", ArgumentSemantic.Strong)]
        string ExpiresAt { get; set; }

        // @property (nonatomic, strong) NSString * redeemableFrom;
        [Export("redeemableFrom", ArgumentSemantic.Strong)]
        string RedeemableFrom { get; set; }

        // @property (nonatomic, strong) NSArray<NITClaim *> * claims;
        [Export("claims", ArgumentSemantic.Strong)]
        NITClaim[] Claims { get; set; }

        // @property (nonatomic, strong) NITImage * icon;
        [Export("icon", ArgumentSemantic.Strong)]
        NITImage Icon { get; set; }

        // @property (readonly, nonatomic) NSDate * expires;
        [Export("expires")]
        NSDate Expires { get; }

        // @property (readonly, nonatomic) NSDate * redeemable;
        [Export("redeemable")]
        NSDate Redeemable { get; }

        // @property (readonly, nonatomic) NSString * title;
        [Export("title")]
        string Title { get; }

        // -(BOOL)hasContentToInclude;
        [Export("hasContentToInclude")]

        bool HasContentToInclude { get; }
    }

    // @interface NITClaim : NITResource <NSCoding>
    [BaseType(typeof(NITResource))]
    interface NITClaim : INSCoding
    {
        // @property (nonatomic, strong) NSString * _Nonnull serialNumber;
        [Export("serialNumber", ArgumentSemantic.Strong)]
        string SerialNumber { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull claimedAt;
        [Export("claimedAt", ArgumentSemantic.Strong)]
        string ClaimedAt { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable redeemedAt;
        [NullAllowed, Export("redeemedAt", ArgumentSemantic.Strong)]
        string RedeemedAt { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull recipeId;
        [Export("recipeId", ArgumentSemantic.Strong)]
        string RecipeId { get; set; }

        // @property (nonatomic, strong) NITCoupon * _Nonnull coupon;
        [Export("coupon", ArgumentSemantic.Strong)]
        NITCoupon Coupon { get; set; }

        // @property (readonly, nonatomic) NSDate * _Nonnull claimed;
        [Export("claimed")]
        NSDate Claimed { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable redeemed;
        [NullAllowed, Export("redeemed")]
        NSDate Redeemed { get; }
    }

    // @interface NITFeedback : NITReactionBundle <NSCoding>
    [BaseType(typeof(NITReactionBundle))]
    interface NITFeedback : INSCoding
    {
        // @property (nonatomic, strong) NSString * _Nonnull question;
        [Export("question", ArgumentSemantic.Strong)]
        string Question { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull recipeId;
        [Export("recipeId", ArgumentSemantic.Strong)]
        string RecipeId { get; set; }
    }

    // @interface NITFeedbackEvent : NITEvent
    [BaseType(typeof(NITEvent))]
    interface NITFeedbackEvent
    {
        // @property (nonatomic, strong) NSString * _Nonnull ID;
        [Export("ID", ArgumentSemantic.Strong)]
        string ID { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull recipeId;
        [Export("recipeId", ArgumentSemantic.Strong)]
        string RecipeId { get; set; }

        // -(instancetype _Nonnull)initWithFeedback:(NITFeedback * _Nonnull)feedback rating:(NSInteger)rating comment:(NSString * _Nonnull)comment;
        [Export("initWithFeedback:rating:comment:")]
        IntPtr Constructor(NITFeedback feedback, nint rating, string comment);

        // -(NITJSONAPI * _Nullable)toJsonAPI:(NITConfiguration * _Nonnull)configuration;
        [Export("toJsonAPI:")]
        [return: NullAllowed]
        NITJSONAPI ToJsonAPI(NITConfiguration configuration);
    }

    // @interface NITCustomJSON : NITReactionBundle <NSCoding>
    [BaseType(typeof(NITReactionBundle))]
    interface NITCustomJSON : INSCoding
    {
        // @property (nonatomic, strong) NSDictionary<NSString *,id> * content;
        [Export("content", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> Content { get; set; }
    }

    // @interface NITSimpleNotification : NITReactionBundle <NSCoding>
    [BaseType(typeof(NITReactionBundle))]
    interface NITSimpleNotification : INSCoding
    {
        // @property (nonatomic, strong) NSString * _Nullable notificationTitle;
        [NullAllowed, Export("notificationTitle", ArgumentSemantic.Strong)]
        string NotificationTitle { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull message;
        [Export("message", ArgumentSemantic.Strong)]
        string Message { get; set; }
    }

    // @interface NITEvent : NSObject
    [BaseType(typeof(NSObject))]
    interface NITEvent
    {
        // -(NSString * _Nonnull)pluginName;
        [Export("pluginName")]

        string PluginName { get; }
    }

    // @interface NITUpload : NITResource <NSCoding>
    [BaseType(typeof(NITResource))]
    interface NITUpload : INSCoding
    {
        // @property (nonatomic, strong) NSDictionary<NSString *,NSString *> * _Nonnull upload;
        [Export("upload", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSString> Upload { get; set; }

        // -(NSURL * _Nullable)url;
        [NullAllowed, Export("url")]

        NSUrl Url { get; }
    }

    // @protocol NITLogger <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NITLogger
    {
        // @required -(void)verboseWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
        [Abstract]
        [Export("verboseWithTag:message:")]
        void VerboseWithTag(string tag, string message);

        // @required -(void)debugWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
        [Abstract]
        [Export("debugWithTag:message:")]
        void DebugWithTag(string tag, string message);

        // @required -(void)infoWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
        [Abstract]
        [Export("infoWithTag:message:")]
        void InfoWithTag(string tag, string message);

        // @required -(void)warningWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
        [Abstract]
        [Export("warningWithTag:message:")]
        void WarningWithTag(string tag, string message);

        // @required -(void)errorWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
        [Abstract]
        [Export("errorWithTag:message:")]
        void ErrorWithTag(string tag, string message);
    }

    // @interface NITLog : NSObject
    [BaseType(typeof(NSObject))]
    interface NITLog
    {
        // +(void)setLogger:(id<NITLogger> _Nonnull)logger;
        [Static]
        [Export("setLogger:")]
        void SetLogger(NITLogger logger);

        // +(void)setLevel:(NITLogLevel)level;
        [Static]
        [Export("setLevel:")]
        void SetLevel(NITLogLevel level);

        // +(void)setLogEnabled:(BOOL)enabled;
        [Static]
        [Export("setLogEnabled:")]
        void SetLogEnabled(bool enabled);
    }

    // @interface NITReactionBundle : NITResource <NSCoding>
    [BaseType(typeof(NITResource))]
    interface NITReactionBundle : INSCoding
    {
        // @property (nonatomic, strong) NSString * notificationMessage;
        [Export("notificationMessage", ArgumentSemantic.Strong)]
        string NotificationMessage { get; set; }
    }

    // @interface NITContentLink : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface NITContentLink : INSCoding
    {
        // @property (nonatomic, strong) NSURL * url;
        [Export("url", ArgumentSemantic.Strong)]
        NSUrl Url { get; set; }

        // @property (nonatomic, strong) NSString * label;
        [Export("label", ArgumentSemantic.Strong)]
        string Label { get; set; }
    }

    // @interface NITTrackingInfo : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface NITTrackingInfo : INSCoding
    {
        // -(BOOL)addExtraWithObject:(id<NSCoding> _Nonnull)object key:(NSString * _Nonnull)key;
        [Export("addExtraWithObject:key:")]
        bool AddExtraWithObject(NSCoding @object, string key);

        // -(NSString * _Nullable)recipeId;
        // -(void)setRecipeId:(NSString * _Nonnull)recipeId;
        [NullAllowed, Export("recipeId")]
        string RecipeId { get; set; }

        //@property (nonatomic, strong) NSMutableDictionary<NSString*, id> *extras;
        [Export("extras")]
        NSDictionary<NSString, NSObject> extras { get; set; }

        // -(NSDictionary * _Nonnull)extrasDictionary;
        [Export("extrasDictionary")]
        NSDictionary ExtrasDictionary();

        // -(BOOL)existsExtraForKey:(NSString * _Nonnull)key;
        [Export("existsExtraForKey:")]
        bool ExistsExtraForKey(string key);

        // +(NITTrackingInfo * _Nonnull)trackingInfoFromRecipeId:(NSString * _Nonnull)recipeId;
        [Static]
        [Export("trackingInfoFromRecipeId:")]
        NITTrackingInfo TrackingInfoFromRecipeId(string recipeId);
    }

    // @interface NITConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    interface NITConfiguration
    {
        // +(NITConfiguration * _Nonnull)defaultConfiguration;
        [Static]
        [Export("defaultConfiguration")]

        NITConfiguration DefaultConfiguration { get; }

        // -(instancetype _Nonnull)initWithUserDefaults:(NSUserDefaults * _Nonnull)userDefaults;
        [Export("initWithUserDefaults:")]
        IntPtr Constructor(NSUserDefaults userDefaults);

        // -(NSString * _Nonnull)paramKeyWithKey:(NSString * _Nonnull)key;
        [Export("paramKeyWithKey:")]
        string ParamKeyWithKey(string key);

        // -(NSString * _Nullable)apiKey;
        // -(void)setApiKey:(NSString * _Nonnull)apiKey;
        [NullAllowed, Export("apiKey")]

        string ApiKey { get; set; }

        // -(NSString * _Nullable)appId;
        // -(void)setAppId:(NSString * _Nonnull)appId;
        [NullAllowed, Export("appId")]

        string AppId { get; set; }

        // -(NSString * _Nullable)profileId;
        // -(void)setProfileId:(NSString * _Nullable)profileId;
        [NullAllowed, Export("profileId")]

        string ProfileId { get; set; }

        // -(NSString * _Nullable)installationId;
        [Export("installationId")]
        [return: NullAllowed]
        string InstallationId();

        // -(void)setInstallationId:(NSString * _Nullable)installationId;
        [Export("setInstallationId:")]
        void SetInstallationId([NullAllowed] string installationId);

        // -(NSString * _Nullable)deviceToken;
        [Export("deviceToken")]
        [return: NullAllowed]
        string DeviceToken();

        // -(void)setDeviceToken:(NSString * _Nonnull)deviceToken;
        [Export("setDeviceToken:")]
        void SetDeviceToken(string deviceToken);

        // -(void)clear;
        [Export("clear")]
        void Clear();
    }

    // @interface NITJSONAPI : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface NITJSONAPI : INSCoding
    {
        // -(instancetype _Nullable)initWithContentsOfFile:(NSString * _Nonnull)path error:(NSError * _Nullable * _Nullable)anError;
        [Export("initWithContentsOfFile:error:")]
        IntPtr Constructor(string path, [NullAllowed] out NSError anError);

        // -(instancetype _Nonnull)initWithDictionary:(NSDictionary * _Nonnull)json;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary json);

        // -(void)setDataWithResourceObject:(NITJSONAPIResource * _Nonnull)resourceObject;
        [Export("setDataWithResourceObject:")]
        void SetDataWithResourceObject(NITJSONAPIResource resourceObject);

        // -(void)setDataWithResourcesObject:(NSArray<NITJSONAPIResource *> * _Nonnull)resources;
        [Export("setDataWithResourcesObject:")]
        void SetDataWithResourcesObject(NITJSONAPIResource[] resources);

        // -(NITJSONAPIResource * _Nullable)firstResourceObject;
        [NullAllowed, Export("firstResourceObject")]

        NITJSONAPIResource FirstResourceObject { get; }

        // -(NSDictionary * _Nonnull)toDictionary;
        [Export("toDictionary")]

        NSDictionary ToDictionary { get; }

        // -(void)registerClass:(Class _Nonnull)cls forType:(NSString * _Nonnull)type;
        [Export("registerClass:forType:")]
        void RegisterClass(Class cls, string type);

        // -(NSArray * _Nonnull)parseToArrayOfObjects;
        [Export("parseToArrayOfObjects")]
        NSObject[] ParseToArrayOfObjects { get; }

        // -(NSArray<NITJSONAPIResource *> * _Nonnull)allResources;
        [Export("allResources")]

        NITJSONAPIResource[] AllResources { get; }

        // -(NSArray<NITJSONAPIResource *> * _Nonnull)rootResources;
        [Export("rootResources")]

        NITJSONAPIResource[] RootResources { get; }

        // -(NSData * _Nullable)dataValue;
        [NullAllowed, Export("dataValue")]

        NSData DataValue { get; }

        // +(NITJSONAPI * _Nonnull)jsonApiWithAttributes:(NSDictionary<NSString *,id> * _Nonnull)attributes type:(NSString * _Nonnull)type;
        [Static]
        [Export("jsonApiWithAttributes:type:")]
        NITJSONAPI JsonApiWithAttributes(NSDictionary<NSString, NSObject> attributes, string type);

        // +(NITJSONAPI * _Nonnull)jsonApiWithArray:(NSArray<NSDictionary<NSString *,id> *> * _Nonnull)resources type:(NSString * _Nonnull)type;
        [Static]
        [Export("jsonApiWithArray:type:")]
        NITJSONAPI JsonApiWithArray(NSDictionary<NSString, NSObject>[] resources, string type);

        // -(id _Nullable)metaForKey:(NSString * _Nonnull)key;
        [Export("metaForKey:")]
        [return: NullAllowed]
        NSObject MetaForKey(string key);
    }

    // @interface NITJSONAPIResource : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface NITJSONAPIResource : INSCoding
    {
        // @property (nonatomic, strong) id _Nullable ID;
        [NullAllowed, Export("ID", ArgumentSemantic.Strong)]
        NSObject ID { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        string Type { get; set; }

        // -(void)addAttributeObject:(id _Nonnull)object forKey:(NSString * _Nonnull)key;
        [Export("addAttributeObject:forKey:")]
        void AddAttributeObject(NSObject @object, string key);

        // -(NSInteger)attributesCount;
        [Export("attributesCount")]

        nint AttributesCount { get; }

        // -(NSDictionary<NSString *,id> * _Nonnull)attributes;
        [Export("attributes")]

        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(NSDictionary<NSString *,id> * _Nonnull)relationships;
        [Export("relationships")]

        NSDictionary<NSString, NSObject> Relationships { get; }

        // -(id _Nullable)attributeForKey:(NSString * _Nonnull)key;
        [Export("attributeForKey:")]
        [return: NullAllowed]
        NSObject AttributeForKey(string key);

        // -(NSDictionary * _Nonnull)toDictionary;
        [Export("toDictionary")]

        NSDictionary ToDictionary { get; }

        // -(NSDictionary * _Nullable)relationshipForKey:(NSString * _Nonnull)key;
        [Export("relationshipForKey:")]
        [return: NullAllowed]
        NSDictionary RelationshipForKey(string key);

        // +(NITJSONAPIResource * _Nonnull)resourceObjectWithDictiornary:(NSDictionary * _Nonnull)dictionary;
        [Static]
        [Export("resourceObjectWithDictiornary:")]
        NITJSONAPIResource ResourceObjectWithDictiornary(NSDictionary dictionary);
    }
}
