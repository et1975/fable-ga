namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<Import("*","Tracker")>] Tracker() =
    member __._trackPageview(): unit = jsNative
    member __._getName(): string = jsNative
    member __._getAccount(): string = jsNative
    member __._getVersion(): string = jsNative
    member __._getVisitorCustomVar(index: float): string = jsNative
    member __._setAccount(): string = jsNative
    member __._setCustomVar(index: float, name: string, value: string, ?opt_scope: float): bool = jsNative
    member __._setSampleRate(newRate: string): unit = jsNative
    member __._setSessionCookieTimeout(cookieTimeoutMillis: float): unit = jsNative
    member __._setSiteSpeedSampleRate(sampleRate: float): unit = jsNative
    member __._setVisitorCookieTimeout(milliseconds: float): unit = jsNative
    member __._trackPageLoadTime(): unit = jsNative

and GoogleAnalyticsCode =
    abstract push: commandArray: ResizeArray<string> -> unit
    abstract push: func: Function -> unit

and GoogleAnalyticsTracker =
    abstract _getTracker: account: string -> Tracker
    abstract _createTracker: opt_account: string * ?opt_name: string -> Tracker
    abstract _getTrackerByName: ?opt_name: string -> Tracker
    abstract _anonymizeIp: unit -> unit

and GoogleAnalytics =
    abstract ``type``: string with get, set
    abstract src: string with get, set
    abstract async: bool with get, set

module UniversalAnalytics =
    type [<StringEnum>] HitType =
        | Pageview | Screenview | Event | Transaction | Item | Social | Exception | Timing

    and FieldsObject =
        abstract affiliation: string option with get, set
        abstract allowAnchor: bool option with get, set
        abstract allowLinker: bool option with get, set
        abstract alwaysSendReferrer: bool option with get, set
        abstract anonymizeIp: bool option with get, set
        abstract appId: string option with get, set
        abstract appInstallerId: string option with get, set
        abstract appName: string option with get, set
        abstract appVersion: string option with get, set
        abstract brand: string option with get, set
        abstract campaignId: string option with get, set
        abstract campaignContent: string option with get, set
        abstract campaignKeyword: string option with get, set
        abstract campaignMedium: string option with get, set
        abstract campaignName: string option with get, set
        abstract campaignSource: string option with get, set
        abstract category: string option with get, set
        abstract clientId: string option with get, set
        abstract contentGroup1: string option with get, set
        abstract contentGroup2: string option with get, set
        abstract contentGroup3: string option with get, set
        abstract contentGroup4: string option with get, set
        abstract contentGroup5: string option with get, set
        abstract contentGroup6: string option with get, set
        abstract contentGroup7: string option with get, set
        abstract contentGroup8: string option with get, set
        abstract contentGroup9: string option with get, set
        abstract contentGroup10: string option with get, set
        abstract cookieName: string option with get, set
        abstract cookieDomain: string option with get, set
        abstract cookieExpires: float option with get, set
        abstract cookiePath: string option with get, set
        abstract coupon: string option with get, set
        abstract creative: string option with get, set
        abstract currencyCode: string option with get, set
        abstract dataSource: string option with get, set
        abstract dimension1: string option with get, set
        abstract dimension2: string option with get, set
        abstract dimension3: string option with get, set
        abstract dimension4: string option with get, set
        abstract dimension5: string option with get, set
        abstract dimension6: string option with get, set
        abstract dimension7: string option with get, set
        abstract dimension8: string option with get, set
        abstract dimension9: string option with get, set
        abstract dimension10: string option with get, set
        abstract dimension11: string option with get, set
        abstract dimension12: string option with get, set
        abstract dimension13: string option with get, set
        abstract dimension14: string option with get, set
        abstract dimension15: string option with get, set
        abstract dimension16: string option with get, set
        abstract dimension17: string option with get, set
        abstract dimension18: string option with get, set
        abstract dimension19: string option with get, set
        abstract dimension20: string option with get, set
        abstract dimension21: string option with get, set
        abstract dimension22: string option with get, set
        abstract dimension23: string option with get, set
        abstract dimension24: string option with get, set
        abstract dimension25: string option with get, set
        abstract dimension26: string option with get, set
        abstract dimension27: string option with get, set
        abstract dimension28: string option with get, set
        abstract dimension29: string option with get, set
        abstract dimension30: string option with get, set
        abstract dimension31: string option with get, set
        abstract dimension32: string option with get, set
        abstract dimension33: string option with get, set
        abstract dimension34: string option with get, set
        abstract dimension35: string option with get, set
        abstract dimension36: string option with get, set
        abstract dimension37: string option with get, set
        abstract dimension38: string option with get, set
        abstract dimension39: string option with get, set
        abstract dimension40: string option with get, set
        abstract dimension41: string option with get, set
        abstract dimension42: string option with get, set
        abstract dimension43: string option with get, set
        abstract dimension44: string option with get, set
        abstract dimension45: string option with get, set
        abstract dimension46: string option with get, set
        abstract dimension47: string option with get, set
        abstract dimension48: string option with get, set
        abstract dimension49: string option with get, set
        abstract dimension50: string option with get, set
        abstract dimension51: string option with get, set
        abstract dimension52: string option with get, set
        abstract dimension53: string option with get, set
        abstract dimension54: string option with get, set
        abstract dimension55: string option with get, set
        abstract dimension56: string option with get, set
        abstract dimension57: string option with get, set
        abstract dimension58: string option with get, set
        abstract dimension59: string option with get, set
        abstract dimension60: string option with get, set
        abstract dimension61: string option with get, set
        abstract dimension62: string option with get, set
        abstract dimension63: string option with get, set
        abstract dimension64: string option with get, set
        abstract dimension65: string option with get, set
        abstract dimension66: string option with get, set
        abstract dimension67: string option with get, set
        abstract dimension68: string option with get, set
        abstract dimension69: string option with get, set
        abstract dimension70: string option with get, set
        abstract dimension71: string option with get, set
        abstract dimension72: string option with get, set
        abstract dimension73: string option with get, set
        abstract dimension74: string option with get, set
        abstract dimension75: string option with get, set
        abstract dimension76: string option with get, set
        abstract dimension77: string option with get, set
        abstract dimension78: string option with get, set
        abstract dimension79: string option with get, set
        abstract dimension80: string option with get, set
        abstract dimension81: string option with get, set
        abstract dimension82: string option with get, set
        abstract dimension83: string option with get, set
        abstract dimension84: string option with get, set
        abstract dimension85: string option with get, set
        abstract dimension86: string option with get, set
        abstract dimension87: string option with get, set
        abstract dimension88: string option with get, set
        abstract dimension89: string option with get, set
        abstract dimension90: string option with get, set
        abstract dimension91: string option with get, set
        abstract dimension92: string option with get, set
        abstract dimension93: string option with get, set
        abstract dimension94: string option with get, set
        abstract dimension95: string option with get, set
        abstract dimension96: string option with get, set
        abstract dimension97: string option with get, set
        abstract dimension98: string option with get, set
        abstract dimension99: string option with get, set
        abstract dimension100: string option with get, set
        abstract dimension101: string option with get, set
        abstract dimension102: string option with get, set
        abstract dimension103: string option with get, set
        abstract dimension104: string option with get, set
        abstract dimension105: string option with get, set
        abstract dimension106: string option with get, set
        abstract dimension107: string option with get, set
        abstract dimension108: string option with get, set
        abstract dimension109: string option with get, set
        abstract dimension110: string option with get, set
        abstract dimension111: string option with get, set
        abstract dimension112: string option with get, set
        abstract dimension113: string option with get, set
        abstract dimension114: string option with get, set
        abstract dimension115: string option with get, set
        abstract dimension116: string option with get, set
        abstract dimension117: string option with get, set
        abstract dimension118: string option with get, set
        abstract dimension119: string option with get, set
        abstract dimension120: string option with get, set
        abstract dimension121: string option with get, set
        abstract dimension122: string option with get, set
        abstract dimension123: string option with get, set
        abstract dimension124: string option with get, set
        abstract dimension125: string option with get, set
        abstract dimension126: string option with get, set
        abstract dimension127: string option with get, set
        abstract dimension128: string option with get, set
        abstract dimension129: string option with get, set
        abstract dimension130: string option with get, set
        abstract dimension131: string option with get, set
        abstract dimension132: string option with get, set
        abstract dimension133: string option with get, set
        abstract dimension134: string option with get, set
        abstract dimension135: string option with get, set
        abstract dimension136: string option with get, set
        abstract dimension137: string option with get, set
        abstract dimension138: string option with get, set
        abstract dimension139: string option with get, set
        abstract dimension140: string option with get, set
        abstract dimension141: string option with get, set
        abstract dimension142: string option with get, set
        abstract dimension143: string option with get, set
        abstract dimension144: string option with get, set
        abstract dimension145: string option with get, set
        abstract dimension146: string option with get, set
        abstract dimension147: string option with get, set
        abstract dimension148: string option with get, set
        abstract dimension149: string option with get, set
        abstract dimension150: string option with get, set
        abstract dimension151: string option with get, set
        abstract dimension152: string option with get, set
        abstract dimension153: string option with get, set
        abstract dimension154: string option with get, set
        abstract dimension155: string option with get, set
        abstract dimension156: string option with get, set
        abstract dimension157: string option with get, set
        abstract dimension158: string option with get, set
        abstract dimension159: string option with get, set
        abstract dimension160: string option with get, set
        abstract dimension161: string option with get, set
        abstract dimension162: string option with get, set
        abstract dimension163: string option with get, set
        abstract dimension164: string option with get, set
        abstract dimension165: string option with get, set
        abstract dimension166: string option with get, set
        abstract dimension167: string option with get, set
        abstract dimension168: string option with get, set
        abstract dimension169: string option with get, set
        abstract dimension170: string option with get, set
        abstract dimension171: string option with get, set
        abstract dimension172: string option with get, set
        abstract dimension173: string option with get, set
        abstract dimension174: string option with get, set
        abstract dimension175: string option with get, set
        abstract dimension176: string option with get, set
        abstract dimension177: string option with get, set
        abstract dimension178: string option with get, set
        abstract dimension179: string option with get, set
        abstract dimension180: string option with get, set
        abstract dimension181: string option with get, set
        abstract dimension182: string option with get, set
        abstract dimension183: string option with get, set
        abstract dimension184: string option with get, set
        abstract dimension185: string option with get, set
        abstract dimension186: string option with get, set
        abstract dimension187: string option with get, set
        abstract dimension188: string option with get, set
        abstract dimension189: string option with get, set
        abstract dimension190: string option with get, set
        abstract dimension191: string option with get, set
        abstract dimension192: string option with get, set
        abstract dimension193: string option with get, set
        abstract dimension194: string option with get, set
        abstract dimension195: string option with get, set
        abstract dimension196: string option with get, set
        abstract dimension197: string option with get, set
        abstract dimension198: string option with get, set
        abstract dimension199: string option with get, set
        abstract dimension200: string option with get, set
        abstract encoding: string option with get, set
        abstract eventAction: string option with get, set
        abstract eventCategory: string option with get, set
        abstract eventLabel: string option with get, set
        abstract eventValue: float option with get, set
        abstract exDescription: string option with get, set
        abstract exFatal: bool option with get, set
        abstract expId: string option with get, set
        abstract expVar: string option with get, set
        abstract flashVersion: string option with get, set
        abstract forceSSL: bool option with get, set
        abstract hitType: HitType option with get, set
        abstract hostname: string option with get, set
        abstract id: string option with get, set
        abstract javaEnabled: bool option with get, set
        abstract language: string option with get, set
        abstract legacyCookieDomain: string option with get, set
        abstract legacyHistoryImport: bool option with get, set
        abstract linkid: string option with get, set
        abstract list: string option with get, set
        abstract location: string option with get, set
        abstract metric1: U2<string, float> option with get, set
        abstract metric2: U2<string, float> option with get, set
        abstract metric3: U2<string, float> option with get, set
        abstract metric4: U2<string, float> option with get, set
        abstract metric5: U2<string, float> option with get, set
        abstract metric6: U2<string, float> option with get, set
        abstract metric7: U2<string, float> option with get, set
        abstract metric8: U2<string, float> option with get, set
        abstract metric9: U2<string, float> option with get, set
        abstract metric10: U2<string, float> option with get, set
        abstract metric11: U2<string, float> option with get, set
        abstract metric12: U2<string, float> option with get, set
        abstract metric13: U2<string, float> option with get, set
        abstract metric14: U2<string, float> option with get, set
        abstract metric15: U2<string, float> option with get, set
        abstract metric16: U2<string, float> option with get, set
        abstract metric17: U2<string, float> option with get, set
        abstract metric18: U2<string, float> option with get, set
        abstract metric19: U2<string, float> option with get, set
        abstract metric20: U2<string, float> option with get, set
        abstract metric21: U2<string, float> option with get, set
        abstract metric22: U2<string, float> option with get, set
        abstract metric23: U2<string, float> option with get, set
        abstract metric24: U2<string, float> option with get, set
        abstract metric25: U2<string, float> option with get, set
        abstract metric26: U2<string, float> option with get, set
        abstract metric27: U2<string, float> option with get, set
        abstract metric28: U2<string, float> option with get, set
        abstract metric29: U2<string, float> option with get, set
        abstract metric30: U2<string, float> option with get, set
        abstract metric31: U2<string, float> option with get, set
        abstract metric32: U2<string, float> option with get, set
        abstract metric33: U2<string, float> option with get, set
        abstract metric34: U2<string, float> option with get, set
        abstract metric35: U2<string, float> option with get, set
        abstract metric36: U2<string, float> option with get, set
        abstract metric37: U2<string, float> option with get, set
        abstract metric38: U2<string, float> option with get, set
        abstract metric39: U2<string, float> option with get, set
        abstract metric40: U2<string, float> option with get, set
        abstract metric41: U2<string, float> option with get, set
        abstract metric42: U2<string, float> option with get, set
        abstract metric43: U2<string, float> option with get, set
        abstract metric44: U2<string, float> option with get, set
        abstract metric45: U2<string, float> option with get, set
        abstract metric46: U2<string, float> option with get, set
        abstract metric47: U2<string, float> option with get, set
        abstract metric48: U2<string, float> option with get, set
        abstract metric49: U2<string, float> option with get, set
        abstract metric50: U2<string, float> option with get, set
        abstract metric51: U2<string, float> option with get, set
        abstract metric52: U2<string, float> option with get, set
        abstract metric53: U2<string, float> option with get, set
        abstract metric54: U2<string, float> option with get, set
        abstract metric55: U2<string, float> option with get, set
        abstract metric56: U2<string, float> option with get, set
        abstract metric57: U2<string, float> option with get, set
        abstract metric58: U2<string, float> option with get, set
        abstract metric59: U2<string, float> option with get, set
        abstract metric60: U2<string, float> option with get, set
        abstract metric61: U2<string, float> option with get, set
        abstract metric62: U2<string, float> option with get, set
        abstract metric63: U2<string, float> option with get, set
        abstract metric64: U2<string, float> option with get, set
        abstract metric65: U2<string, float> option with get, set
        abstract metric66: U2<string, float> option with get, set
        abstract metric67: U2<string, float> option with get, set
        abstract metric68: U2<string, float> option with get, set
        abstract metric69: U2<string, float> option with get, set
        abstract metric70: U2<string, float> option with get, set
        abstract metric71: U2<string, float> option with get, set
        abstract metric72: U2<string, float> option with get, set
        abstract metric73: U2<string, float> option with get, set
        abstract metric74: U2<string, float> option with get, set
        abstract metric75: U2<string, float> option with get, set
        abstract metric76: U2<string, float> option with get, set
        abstract metric77: U2<string, float> option with get, set
        abstract metric78: U2<string, float> option with get, set
        abstract metric79: U2<string, float> option with get, set
        abstract metric80: U2<string, float> option with get, set
        abstract metric81: U2<string, float> option with get, set
        abstract metric82: U2<string, float> option with get, set
        abstract metric83: U2<string, float> option with get, set
        abstract metric84: U2<string, float> option with get, set
        abstract metric85: U2<string, float> option with get, set
        abstract metric86: U2<string, float> option with get, set
        abstract metric87: U2<string, float> option with get, set
        abstract metric88: U2<string, float> option with get, set
        abstract metric89: U2<string, float> option with get, set
        abstract metric90: U2<string, float> option with get, set
        abstract metric91: U2<string, float> option with get, set
        abstract metric92: U2<string, float> option with get, set
        abstract metric93: U2<string, float> option with get, set
        abstract metric94: U2<string, float> option with get, set
        abstract metric95: U2<string, float> option with get, set
        abstract metric96: U2<string, float> option with get, set
        abstract metric97: U2<string, float> option with get, set
        abstract metric98: U2<string, float> option with get, set
        abstract metric99: U2<string, float> option with get, set
        abstract metric100: U2<string, float> option with get, set
        abstract metric101: U2<string, float> option with get, set
        abstract metric102: U2<string, float> option with get, set
        abstract metric103: U2<string, float> option with get, set
        abstract metric104: U2<string, float> option with get, set
        abstract metric105: U2<string, float> option with get, set
        abstract metric106: U2<string, float> option with get, set
        abstract metric107: U2<string, float> option with get, set
        abstract metric108: U2<string, float> option with get, set
        abstract metric109: U2<string, float> option with get, set
        abstract metric110: U2<string, float> option with get, set
        abstract metric111: U2<string, float> option with get, set
        abstract metric112: U2<string, float> option with get, set
        abstract metric113: U2<string, float> option with get, set
        abstract metric114: U2<string, float> option with get, set
        abstract metric115: U2<string, float> option with get, set
        abstract metric116: U2<string, float> option with get, set
        abstract metric117: U2<string, float> option with get, set
        abstract metric118: U2<string, float> option with get, set
        abstract metric119: U2<string, float> option with get, set
        abstract metric120: U2<string, float> option with get, set
        abstract metric121: U2<string, float> option with get, set
        abstract metric122: U2<string, float> option with get, set
        abstract metric123: U2<string, float> option with get, set
        abstract metric124: U2<string, float> option with get, set
        abstract metric125: U2<string, float> option with get, set
        abstract metric126: U2<string, float> option with get, set
        abstract metric127: U2<string, float> option with get, set
        abstract metric128: U2<string, float> option with get, set
        abstract metric129: U2<string, float> option with get, set
        abstract metric130: U2<string, float> option with get, set
        abstract metric131: U2<string, float> option with get, set
        abstract metric132: U2<string, float> option with get, set
        abstract metric133: U2<string, float> option with get, set
        abstract metric134: U2<string, float> option with get, set
        abstract metric135: U2<string, float> option with get, set
        abstract metric136: U2<string, float> option with get, set
        abstract metric137: U2<string, float> option with get, set
        abstract metric138: U2<string, float> option with get, set
        abstract metric139: U2<string, float> option with get, set
        abstract metric140: U2<string, float> option with get, set
        abstract metric141: U2<string, float> option with get, set
        abstract metric142: U2<string, float> option with get, set
        abstract metric143: U2<string, float> option with get, set
        abstract metric144: U2<string, float> option with get, set
        abstract metric145: U2<string, float> option with get, set
        abstract metric146: U2<string, float> option with get, set
        abstract metric147: U2<string, float> option with get, set
        abstract metric148: U2<string, float> option with get, set
        abstract metric149: U2<string, float> option with get, set
        abstract metric150: U2<string, float> option with get, set
        abstract metric151: U2<string, float> option with get, set
        abstract metric152: U2<string, float> option with get, set
        abstract metric153: U2<string, float> option with get, set
        abstract metric154: U2<string, float> option with get, set
        abstract metric155: U2<string, float> option with get, set
        abstract metric156: U2<string, float> option with get, set
        abstract metric157: U2<string, float> option with get, set
        abstract metric158: U2<string, float> option with get, set
        abstract metric159: U2<string, float> option with get, set
        abstract metric160: U2<string, float> option with get, set
        abstract metric161: U2<string, float> option with get, set
        abstract metric162: U2<string, float> option with get, set
        abstract metric163: U2<string, float> option with get, set
        abstract metric164: U2<string, float> option with get, set
        abstract metric165: U2<string, float> option with get, set
        abstract metric166: U2<string, float> option with get, set
        abstract metric167: U2<string, float> option with get, set
        abstract metric168: U2<string, float> option with get, set
        abstract metric169: U2<string, float> option with get, set
        abstract metric170: U2<string, float> option with get, set
        abstract metric171: U2<string, float> option with get, set
        abstract metric172: U2<string, float> option with get, set
        abstract metric173: U2<string, float> option with get, set
        abstract metric174: U2<string, float> option with get, set
        abstract metric175: U2<string, float> option with get, set
        abstract metric176: U2<string, float> option with get, set
        abstract metric177: U2<string, float> option with get, set
        abstract metric178: U2<string, float> option with get, set
        abstract metric179: U2<string, float> option with get, set
        abstract metric180: U2<string, float> option with get, set
        abstract metric181: U2<string, float> option with get, set
        abstract metric182: U2<string, float> option with get, set
        abstract metric183: U2<string, float> option with get, set
        abstract metric184: U2<string, float> option with get, set
        abstract metric185: U2<string, float> option with get, set
        abstract metric186: U2<string, float> option with get, set
        abstract metric187: U2<string, float> option with get, set
        abstract metric188: U2<string, float> option with get, set
        abstract metric189: U2<string, float> option with get, set
        abstract metric190: U2<string, float> option with get, set
        abstract metric191: U2<string, float> option with get, set
        abstract metric192: U2<string, float> option with get, set
        abstract metric193: U2<string, float> option with get, set
        abstract metric194: U2<string, float> option with get, set
        abstract metric195: U2<string, float> option with get, set
        abstract metric196: U2<string, float> option with get, set
        abstract metric197: U2<string, float> option with get, set
        abstract metric198: U2<string, float> option with get, set
        abstract metric199: U2<string, float> option with get, set
        abstract metric200: U2<string, float> option with get, set
        abstract name: string option with get, set
        abstract nonInteraction: bool option with get, set
        abstract option: string option with get, set
        abstract page: string option with get, set
        abstract position: U2<float, string> option with get, set
        abstract price: string option with get, set
        abstract quantity: float option with get, set
        abstract queueTime: float option with get, set
        abstract referrer: string option with get, set
        abstract revenue: string option with get, set
        abstract sampleRate: float option with get, set
        abstract sessionControl: string option with get, set
        abstract siteSpeedSampleRate: float option with get, set
        abstract screenColors: string option with get, set
        abstract screenName: string option with get, set
        abstract screenResolution: string option with get, set
        abstract shipping: string option with get, set
        abstract socialAction: string option with get, set
        abstract socialNetwork: string option with get, set
        abstract socialTarget: string option with get, set
        abstract some: string option with get, set
        abstract step: U2<bool, float> option with get, set
        abstract storage: string option with get, set
        abstract storeGac: bool option with get, set
        abstract tax: string option with get, set
        abstract timingCategory: string option with get, set
        abstract timingLabel: string option with get, set
        abstract timingValue: float option with get, set
        abstract timingVar: string option with get, set
        abstract title: string option with get, set
        abstract transport: string option with get, set
        abstract useBeacon: bool option with get, set
        abstract userId: string option with get, set
        abstract variant: string option with get, set
        abstract viewportSize: string option with get, set
        abstract hitCallback: unit -> unit

    and ga =
        abstract l: float with get, set
        abstract q: ResizeArray<obj> with get, set
        [<Emit("$0($1...)")>] abstract Invoke_event: eventCategory: string * eventAction: string * ?eventLabel: string * ?eventValue: float * ?fieldsObject: FieldsObject -> unit
        [<Emit("$0($1...)")>] abstract Invoke_event: fieldsObject: obj -> unit
        [<Emit("$0($1...)")>] abstract Invoke_send: fieldsObject: obj -> unit
        [<Emit("$0($1...)")>] abstract Invoke_pageview: page: string -> unit
        [<Emit("$0($1...)")>] abstract Invoke_social: socialNetwork: string * socialAction: string * socialTarget: string -> unit
        [<Emit("$0($1...)")>] abstract Invoke_social: fieldsObject: obj -> unit
        [<Emit("$0($1...)")>] abstract Invoke_timing: timingCategory: string * timingVar: string * timingValue: float -> unit
        [<Emit("$0($1...)")>] abstract Invoke_timing: fieldsObject: obj -> unit
        [<Emit("$0($1...)")>] abstract Invoke_send: fieldsObject: FieldsObject -> unit
        [<Emit("$0($1...)")>] abstract Invoke: command: string * hitType: HitType * [<ParamArray>] fields: obj[] -> unit
        [<Emit("$0($1...)")>] abstract Invoke_require: pluginName: string * ?pluginOptions: obj -> unit
        [<Emit("$0($1...)")>] abstract Invoke_provide: pluginName: string * pluginConstructor: Func<Tracker, obj, unit> -> unit
        [<Emit("$0($1...)")>] abstract Invoke_create: trackingId: string * ?cookieDomain: string * ?name: string * ?fieldsObject: FieldsObject -> unit
        [<Emit("$0($1...)")>] abstract Invoke_remove: unit -> unit
        [<Emit("$0($1...)")>] abstract Invoke: command: string * [<ParamArray>] fields: obj[] -> unit
        [<Emit("$0($1...)")>] abstract Invoke: readyCallback: Func<Tracker, unit> -> unit
        abstract create: trackingId: string * cookieDomain: string * name: string * ?fieldsObject: FieldsObject -> Tracker
        abstract create: trackingId: string * cookieDomain: string * ?fieldsObject: FieldsObject -> Tracker
        abstract create: trackingId: string * ?fieldsObject: FieldsObject -> Tracker
        abstract getAll: unit -> ResizeArray<Tracker>
        abstract getByName: name: string -> Tracker
        abstract remove: name: string -> unit

    and Tracker =
        abstract get: fieldName: string -> obj
        abstract set: fieldName: string * fieldValue: obj -> unit
        abstract set: fieldsObject: obj -> unit
        abstract send: hitType: string * [<ParamArray>] fields: obj[] -> unit
        abstract send: hitType: string * fieldsObject: obj -> unit

    and Model =
        abstract get: fieldName: string -> obj
        abstract set: fieldName: string * fieldValue: obj * ?temporary: bool -> unit
        abstract set: fields: obj * ?fieldValue: obj * ?temporary: bool -> unit


type [<Erase>]Globals =
    [<Global>] static member gaClassic with get(): GoogleAnalytics = jsNative and set(v: GoogleAnalytics): unit = jsNative
    [<Global>] static member ga with get(): UniversalAnalytics.ga = jsNative and set(v: UniversalAnalytics.ga): unit = jsNative
    [<Global>] static member _gaq with get(): GoogleAnalyticsCode = jsNative and set(v: GoogleAnalyticsCode): unit = jsNative
    [<Global>] static member _gat with get(): GoogleAnalyticsTracker = jsNative and set(v: GoogleAnalyticsTracker): unit = jsNative

