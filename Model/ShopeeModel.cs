using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotShopee
{
    public static class Shopee
    {
        public class PostMessage<T>
        {
            public string source { get; set; }
            public bool isError { get; set; }
            public T data { get; set; }
        }

        public class UserData
        {
            public string token { get; set; }
            public string p_token { get; set; }
            public User user { get; set; }
            public long? version { get; set; }
            public bool? is_ccu_grey { get; set; }
        }

        public class User
        {
            public long? id { get; set; }
            public string uid { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string avatar { get; set; }
            public string avatar_hash { get; set; }
            public string locale { get; set; }
            public long? shop_id { get; set; }
            public string country { get; set; }
            public string status { get; set; }
            public bool? is_seller { get; set; }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Account
        {
            public long? user_id { get; set; }
            public bool? is_new_user { get; set; }
            public DefaultAddress default_address { get; set; }
            public long? adult_consent { get; set; }
            public long? birth_timestamp { get; set; }
            public string portrait { get; set; }
            public string username { get; set; }
            public long? status { get; set; }
        }

        public class AgeGate
        {
            public object kyc { get; set; }
        }

        public class Attr
        {
            public string name { get; set; }
            public string value { get; set; }
            public long? id { get; set; }
            public bool? is_timestamp { get; set; }
            public object brand_option { get; set; }
            public long? val_id { get; set; }
            public string url { get; set; }
        }

        public class Attribute
        {
            public string name { get; set; }
            public string value { get; set; }
            public long? id { get; set; }
            public bool? is_timestamp { get; set; }
            public object brand_option { get; set; }
            public long? val_id { get; set; }
            public object url { get; set; }
        }

        public class Category
        {
            public long? catid { get; set; }
            public string display_name { get; set; }
            public bool? no_sub { get; set; }
            public bool? is_default_subcat { get; set; }
        }

        public class ChannelDeliveryInfo
        {
            public bool? has_edt { get; set; }
            public string display_mode { get; set; }
            public long? estimated_delivery_date_from { get; set; }
            public long? estimated_delivery_date_to { get; set; }
            public long? estimated_delivery_time_min { get; set; }
            public long? estimated_delivery_time_max { get; set; }
            public string delay_message { get; set; }
        }

        public class ChannelInfo
        {
            public long? channel_id { get; set; }
            public string name { get; set; }
            public Price price { get; set; }
            public PriceBeforeDiscount price_before_discount { get; set; }
            public ChannelDeliveryInfo channel_delivery_info { get; set; }
            public object channel_promotion_infos { get; set; }
            public Warning warning { get; set; }
        }

        public class ChannelPromotionInfo
        {
            public long? rule_id { get; set; }
            public long? type { get; set; }
            public long? display_mode { get; set; }
            public long? discount_off { get; set; }
            public MinSpend min_spend { get; set; }
            public long? cap { get; set; }
        }

        public class CoinEarnItem
        {
            public long? coin_earn { get; set; }
        }

        public class CoinInfo
        {
            public long? spend_cash_unit { get; set; }
            public List<CoinEarnItem> coin_earn_items { get; set; }
            public object coin_earn_label { get; set; }
        }

        public class CustomisedLabel
        {
            public string content { get; set; }
        }

        public class Data
        {
            public Item item { get; set; }
            public Account account { get; set; }
            public ProductImages product_images { get; set; }
            public ProductPrice product_price { get; set; }
            public object flash_sale { get; set; }
            public FlashSalePreview flash_sale_preview { get; set; }
            public object deep_discount { get; set; }
            public object exclusive_price { get; set; }
            public object exclusive_price_cta { get; set; }
            public ProductMeta product_meta { get; set; }
            public ProductReview product_review { get; set; }
            public PromotionInfo promotion_info { get; set; }
            public AgeGate age_gate { get; set; }
            public ShippingMeta shipping_meta { get; set; }
            public ProductShipping product_shipping { get; set; }
            public List<ShopVoucher> shop_vouchers { get; set; }
            public object free_return { get; set; }
            public CoinInfo coin_info { get; set; }
            public ProductAttributes product_attributes { get; set; }
            public ShopDetailed shop_detailed { get; set; }
        }

        public class DefaultAddress
        {
            public string state { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string town { get; set; }
            public string zip_code { get; set; }
            public object address { get; set; }
            public object region { get; set; }
        }

        public class DefaultFormat
        {
            public long? format { get; set; }
            public string defn { get; set; }
            public string profile { get; set; }
            public string path { get; set; }
            public string url { get; set; }
            public long? width { get; set; }
            public long? height { get; set; }
        }

        public class Extinfo
        {
            public List<long?> tier_index { get; set; }
            public bool? is_pre_order { get; set; }
            public long? estimated_days { get; set; }
        }

        public class FeCategory
        {
            public long? catid { get; set; }
            public string display_name { get; set; }
            public bool? no_sub { get; set; }
            public bool? is_default_subcat { get; set; }
        }

        public class FirstTierVariation
        {
            public string name { get; set; }
            public string image { get; set; }
            public long? summed_stock { get; set; }
        }

        public class FlashSalePreview
        {
            public long promotionid { get; set; }
            public long? flash_sale_type { get; set; }
            public long? start_time { get; set; }
            public object extra_discount_info { get; set; }
        }

        public class Format
        {
            public long? format { get; set; }
            public string defn { get; set; }
            public string profile { get; set; }
            public string path { get; set; }
            public string url { get; set; }
            public long? width { get; set; }
            public long? height { get; set; }
        }

        public class FreeShipping
        {
            public object min_spend { get; set; }
            public bool? has_fss { get; set; }
        }

        public class GroupedChannelInfosByServiceType
        {
            public string name { get; set; }
            public List<ChannelInfo> channel_infos { get; set; }
        }

        public class InstallmentInfo
        {
            public List<object> installment_plans { get; set; }
            public object max_installment_plan { get; set; }
            public long? panel_status { get; set; }
            public object recommended_installment_plan { get; set; }
            public long? interest_rate_discounted_type { get; set; }
        }

        public class Insurance
        {
            public List<Row> rows { get; set; }
        }

        public class Item
        {
            public long item_id { get; set; }
            public long? shop_id { get; set; }
            public string item_status { get; set; }
            public long? status { get; set; }
            public long? item_type { get; set; }
            public string reference_item_id { get; set; }
            public string title { get; set; }
            public string image { get; set; }
            public List<long?> label_ids { get; set; }
            public bool? is_adult { get; set; }
            public bool? is_preview { get; set; }
            public long? flag { get; set; }
            public bool? is_service_by_shopee { get; set; }
            public long? condition { get; set; }
            public long? cat_id { get; set; }
            public bool? has_low_fulfillment_rate { get; set; }
            public object is_live_streaming_price { get; set; }
            public string currency { get; set; }
            public string brand { get; set; }
            public long? brand_id { get; set; }
            public long? show_discount { get; set; }
            public long? ctime { get; set; }
            public ItemRating item_rating { get; set; }
            public long? cb_option { get; set; }
            public bool? has_model_with_available_shopee_stock { get; set; }
            public string shop_location { get; set; }
            public List<Attribute> attributes { get; set; }
            public RichTextDescription rich_text_description { get; set; }
            public object invoice_option { get; set; }
            public object is_category_failed { get; set; }
            public bool? is_prescription_item { get; set; }
            public object preview_info { get; set; }
            public bool? show_prescription_feed { get; set; }
            public bool? is_alcohol_product { get; set; }
            public bool? is_infant_milk_formula_product { get; set; }
            public bool? is_unavailable { get; set; }
            public bool? is_partial_fulfilled { get; set; }
            public bool? is_presale { get; set; }
            public object is_presale_deposit_item { get; set; }
            public object is_presale_deposit_made { get; set; }
            public string description { get; set; }
            public List<Category> categories { get; set; }
            public List<FeCategory> fe_categories { get; set; }
            public bool? item_has_video { get; set; }
            public object presale_dday_start_time { get; set; }
            public List<Model> models { get; set; }
            public List<TierVariation> tier_variations { get; set; }
            public string size_chart { get; set; }
            public object size_chart_info { get; set; }
            public long? welcome_package_type { get; set; }
            public bool? is_free_gift { get; set; }
            public object deep_discount { get; set; }
            public bool? is_low_price_eligible { get; set; }
            public object bundle_deal_info { get; set; }
            public object add_on_deal_info { get; set; }
            public long? shipping_icon_type { get; set; }
            public long? badge_icon_type { get; set; }
            public SplInfo spl_info { get; set; }
            public long? estimated_days { get; set; }
            public bool? is_pre_order { get; set; }
            public bool? is_free_shipping { get; set; }
            public object overall_purchase_limit { get; set; }
            public long? min_purchase_limit { get; set; }
            public bool? is_hide_stock { get; set; }
            public long? stock { get; set; }
            public long? normal_stock { get; set; }
            public long? current_promotion_reserved_stock { get; set; }
            public bool? can_use_wholesale { get; set; }
            public List<object> wholesale_tier_list { get; set; }
            public long? price { get; set; }
            public long? raw_discount { get; set; }
            public object hidden_price_display { get; set; }
            public long price_min { get; set; }
            public long price_max { get; set; }
            public long price_before_discount { get; set; }
            public long price_min_before_discount { get; set; }
            public long price_max_before_discount { get; set; }
            public long? other_stock { get; set; }
            public long? discount_stock { get; set; }
            public bool? current_promotion_has_reserve_stock { get; set; }
            public object complaint_policy { get; set; }
            public bool? show_recycling_info { get; set; }
        }

        public class ItemInstallmentEligibility
        {
            public bool? is_cc_installment_payment_eligible { get; set; }
            public bool? is_non_cc_installment_payment_eligible { get; set; }
        }

        public class ItemRating
        {
            public double rating_star { get; set; }
        }

        public class KeyMeasurement
        {
            public List<long?> size_attr_value_id { get; set; }
            public object labels { get; set; }
        }

        public class MinSpend
        {
            public object single_value { get; set; }
            public long? range_min { get; set; }
            public long? range_max { get; set; }
            public object price_mask { get; set; }
        }

        public class Model
        {
            public object item_id { get; set; }
            public long? status { get; set; }
            public long? current_promotion_reserved_stock { get; set; }
            public string name { get; set; }
            public object promotion_id { get; set; }
            public long? price { get; set; }
            public List<PriceStock> price_stocks { get; set; }
            public bool? current_promotion_has_reserve_stock { get; set; }
            public long? normal_stock { get; set; }
            public Extinfo extinfo { get; set; }
            public object price_before_discount { get; set; }
            public object model_id { get; set; }
            public long? stock { get; set; }
            public bool? has_gimmick_tag { get; set; }
            public KeyMeasurement key_measurement { get; set; }
            public long? sold { get; set; }
        }

        public class ParagraphList
        {
            public long? type { get; set; }
            public string text { get; set; }
            public string img_id { get; set; }
            public double? ratio { get; set; }
            public long? empty_paragraph_count { get; set; }
        }

        public class PreSelectedShippingChannel
        {
            public long? channel_id { get; set; }
            public string name { get; set; }
            public Price price { get; set; }
            public PriceBeforeDiscount price_before_discount { get; set; }
            public ChannelDeliveryInfo channel_delivery_info { get; set; }
            public List<object> channel_promotion_infos { get; set; }
            public Warning warning { get; set; }
        }

        public class Price
        {
            public long? single_value { get; set; }
            public long range_min { get; set; }
            public long range_max { get; set; }
            public object price_mask { get; set; }
        }

        public class PriceBeforeDiscount
        {
            public long? single_value { get; set; }
            public long range_min { get; set; }
            public long range_max { get; set; }
            public object price_mask { get; set; }
        }

        public class PriceStock
        {
            public long? allocated_stock { get; set; }
            public List<StockBreakdownByLocation> stock_breakdown_by_location { get; set; }
            public long? promotion_type { get; set; }
        }

        public class ProductAttributes
        {
            public List<Attr> attrs { get; set; }
            public object categories { get; set; }
        }

        public class ProductImages
        {
            public Video video { get; set; }
            public List<string> images { get; set; }
            public List<FirstTierVariation> first_tier_variations { get; set; }
            public List<object> sorted_variation_image_index_list { get; set; }
            public object overlay { get; set; }
            public object makeup_preview { get; set; }
            public string abnormal_status { get; set; }
            public List<object> promotion_images { get; set; }
            public object long_images { get; set; }
            public List<object> shopee_video_info_list { get; set; }
            public object shopee_video_rcmd_info { get; set; }
            public object shopee_video_req_id { get; set; }
            public object skincam { get; set; }
        }

        public class ProductMeta
        {
            public bool? show_lowest_price_guarantee { get; set; }
            public bool? show_original_guarantee { get; set; }
            public bool? show_best_price_guarantee { get; set; }
            public bool? show_official_shop_label_in_title { get; set; }
            public bool? show_shopee_verified_label { get; set; }
        }

        public class ProductPrice
        {
            public long? discount { get; set; }
            public object spl_installment_info { get; set; }
            public string pack_size { get; set; }
            public bool? hide_price { get; set; }
            public Price price { get; set; }
            public PriceBeforeDiscount price_before_discount { get; set; }
            public object presale_price { get; set; }
            public object lowest_past_price { get; set; }
            public object labels { get; set; }
        }

        public class ProductReview
        {
            public double rating_star { get; set; }
            public List<long?> rating_count { get; set; }
            public long? total_rating_count { get; set; }
            public long? historical_sold { get; set; }
            public long? global_sold { get; set; }
            public bool? liked { get; set; }
            public long? liked_count { get; set; }
            public long? cmt_count { get; set; }
            public object should_move_ratings_above { get; set; }
            public object review_rcmd_exp_group { get; set; }
        }

        public class ProductShipping
        {
            public FreeShipping free_shipping { get; set; }
            public ShippingFeeInfo shipping_fee_info { get; set; }
            public bool? show_shipping_to { get; set; }
            public List<UngroupedChannelInfo> ungrouped_channel_infos { get; set; }
            public List<GroupedChannelInfosByServiceType> grouped_channel_infos_by_service_type { get; set; }
            public string also_available_channel_name { get; set; }
            public PreSelectedShippingChannel pre_selected_shipping_channel { get; set; }
            public bool? show_grouped_channel_first { get; set; }
        }

        public class PromotionInfo
        {
            public object spl { get; set; }
            public object spl_lite { get; set; }
            public object installment { get; set; }
            public object wholesale { get; set; }
            public Insurance insurance { get; set; }
            public ItemInstallmentEligibility item_installment_eligibility { get; set; }
        }

        public class RichTextDescription
        {
            public List<ParagraphList> paragraph_list { get; set; }
        }

        public class ItemDetail
        {
            public object bff_meta { get; set; }
            public object error { get; set; }
            public object error_msg { get; set; }
            public Data data { get; set; }
        }

        public class Row
        {
            public string product_id { get; set; }
            public string title { get; set; }
            public string text { get; set; }
            public string badge_text { get; set; }
            public string url { get; set; }
        }

        public class SessionInfo
        {
            public bool? is_show { get; set; }
            public long? session_id { get; set; }
            public long? view_count { get; set; }
            public string session_url { get; set; }
            public string preview_image { get; set; }
        }

        public class SessionInfo2
        {
            public bool? is_show { get; set; }
            public long? session_id { get; set; }
            public long? view_count { get; set; }
            public string session_url { get; set; }
            public string preview_image { get; set; }
        }

        public class ShippingFeeInfo
        {
            public string ship_from_location { get; set; }
            public Price price { get; set; }
            public long? shipping_icon_type { get; set; }
            public object warning { get; set; }
        }

        public class ShippingMeta
        {
            public bool? show_fufilled_by_shopee { get; set; }
            public bool? show_cod { get; set; }
            public bool? show_mart { get; set; }
            public bool? show_next_day_delivery { get; set; }
        }

        public class ShopDetailed
        {
            public long? shopid { get; set; }
            public long? userid { get; set; }
            public long? last_active_time { get; set; }
            public bool? vacation { get; set; }
            public string place { get; set; }
            public Account account { get; set; }
            public bool? is_shopee_verified { get; set; }
            public bool? is_preferred_plus_seller { get; set; }
            public bool? is_official_shop { get; set; }
            public string shop_location { get; set; }
            public long? item_count { get; set; }
            public double rating_star { get; set; }
            public long? response_rate { get; set; }
            public SessionInfo session_info { get; set; }
            public string name { get; set; }
            public long? ctime { get; set; }
            public long? response_time { get; set; }
            public long? follower_count { get; set; }
            public bool? show_official_shop_label { get; set; }
            public long? rating_bad { get; set; }
            public long? rating_good { get; set; }
            public long? rating_normal { get; set; }
            public List<SessionInfo> session_infos { get; set; }
            public long? status { get; set; }
            public object is_individual_seller { get; set; }
            public bool? is_mart { get; set; }
            public object favorite_shop_info { get; set; }
            public bool? is_3pf { get; set; }
        }

        public class ShopVoucher
        {
            public object promotionid { get; set; }
            public string voucher_code { get; set; }
            public string signature { get; set; }
            public object use_type { get; set; }
            public object platform_type { get; set; }
            public object voucher_market_type { get; set; }
            public object min_spend { get; set; }
            public object used_price { get; set; }
            public object current_spend { get; set; }
            public bool? product_limit { get; set; }
            public long? quota_type { get; set; }
            public long? percentage_claimed { get; set; }
            public long? percentage_used { get; set; }
            public long? start_time { get; set; }
            public long? end_time { get; set; }
            public object collect_time { get; set; }
            public object claim_start_time { get; set; }
            public object valid_days { get; set; }
            public long? reward_type { get; set; }
            public object reward_percentage { get; set; }
            public object reward_value { get; set; }
            public object reward_cap { get; set; }
            public object coin_earned { get; set; }
            public object title { get; set; }
            public object use_link { get; set; }
            public string icon_hash { get; set; }
            public string icon_text { get; set; }
            public object icon_url { get; set; }
            public List<CustomisedLabel> customised_labels { get; set; }
            public object customised_product_scope_tags { get; set; }
            public long? shop_id { get; set; }
            public object shop_name { get; set; }
            public bool? is_shop_preferred { get; set; }
            public bool? is_shop_official { get; set; }
            public object shop_count { get; set; }
            public object ui_display_type { get; set; }
            public object customised_mall_name { get; set; }
            public object small_icon_list { get; set; }
            public object dp_category_name { get; set; }
            public object invalid_message_code { get; set; }
            public object invalid_message { get; set; }
            public object display_labels { get; set; }
            public object wallet_redeemable { get; set; }
            public object customer_reference_id { get; set; }
            public object fully_redeemed { get; set; }
            public object has_expired { get; set; }
            public object disabled { get; set; }
            public object voucher_external_market_type { get; set; }
            public object now_food_extra_info { get; set; }
            public object airpay_opv_extra_info { get; set; }
            public object partner_extra_info { get; set; }
            public long? discount_value { get; set; }
            public long? discount_percentage { get; set; }
            public long? discount_cap { get; set; }
            public object coin_percentage { get; set; }
            public object coin_cap { get; set; }
            public object usage_limit { get; set; }
            public object used_count { get; set; }
            public object left_count { get; set; }
            public object shopee_wallet_only { get; set; }
            public object new_user_only { get; set; }
            public object description { get; set; }
            public object shop_logo { get; set; }
            public long? error_code { get; set; }
            public bool? is_claimed_before { get; set; }
            public object customised_product_scope_tag_image_hash { get; set; }
            public long? usage_limit_per_user { get; set; }
            public long? remaining_usage_limit { get; set; }
            public object action { get; set; }
            public object sub_icon_text { get; set; }
            public object is_customised_icon { get; set; }
            public object fixed_flag { get; set; }
            public object customised_flag { get; set; }
            public object fsv_voucher_card_ui_info { get; set; }
        }

        public class SplInfo
        {
            public InstallmentInfo installment_info { get; set; }
            public UserCreditInfo user_credit_info { get; set; }
            public long? channel_id { get; set; }
            public bool? show_spl { get; set; }
            public object show_spl_lite { get; set; }
        }

        public class StockBreakdownByLocation
        {
            public string location_id { get; set; }
            public long? available_stock { get; set; }
            public long? fulfilment_type { get; set; }
            public long? address_id { get; set; }
            public object allocated_stock { get; set; }
        }

        public class TierVariation
        {
            public string name { get; set; }
            public List<string> options { get; set; }
            public List<string> images { get; set; }
            public object properties { get; set; }
            public long? type { get; set; }
            public object summed_stocks { get; set; }
        }

        public class UngroupedChannelInfo
        {
            public long? channel_id { get; set; }
            public string name { get; set; }
            public Price price { get; set; }
            public PriceBeforeDiscount price_before_discount { get; set; }
            public ChannelDeliveryInfo channel_delivery_info { get; set; }
            public List<ChannelPromotionInfo> channel_promotion_infos { get; set; }
            public object warning { get; set; }
        }

        public class UserCreditInfo
        {
            public long? user_status { get; set; }
            public string display_text { get; set; }
            public string display_color { get; set; }
            public string partners_link { get; set; }
            public string tracking_info { get; set; }
        }

        public class Video
        {
            public string video_id { get; set; }
            public string thumb_url { get; set; }
            public long? duration { get; set; }
            public long? version { get; set; }
            public string vid { get; set; }
            public List<Format> formats { get; set; }
            public DefaultFormat default_format { get; set; }
            public string mms_data { get; set; }
            public object item_cover { get; set; }
        }

        public class Warning
        {
            public string type { get; set; }
            public string warning_msg { get; set; }
        }

        public class InfoPayment
        {
            // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
            public class _8002
            {
                public ChannelData channel_data { get; set; }
                public CodData cod_data { get; set; }
                public DeliveryData delivery_data { get; set; }
                public ShippingFeeData shipping_fee_data { get; set; }
            }

            public class _80024
            {
                public ChannelData channel_data { get; set; }
                public CodData cod_data { get; set; }
                public DeliveryData delivery_data { get; set; }
                public ShippingFeeData shipping_fee_data { get; set; }
            }

            public class _8003
            {
                public ChannelData channel_data { get; set; }
                public CodData cod_data { get; set; }
                public DeliveryData delivery_data { get; set; }
                public ShippingFeeData shipping_fee_data { get; set; }
            }

            public class _8005
            {
                public ChannelData channel_data { get; set; }
                public CodData cod_data { get; set; }
                public DeliveryData delivery_data { get; set; }
                public ShippingFeeData shipping_fee_data { get; set; }
            }

            public class _80055
            {
                public ChannelData channel_data { get; set; }
                public CodData cod_data { get; set; }
                public DeliveryData delivery_data { get; set; }
                public ShippingFeeData shipping_fee_data { get; set; }
            }

            public class _8006
            {
                public ChannelData channel_data { get; set; }
                public CodData cod_data { get; set; }
                public DeliveryData delivery_data { get; set; }
                public ShippingFeeData shipping_fee_data { get; set; }
            }

            public class _80099
            {
                public ChannelData channel_data { get; set; }
                public CodData cod_data { get; set; }
                public DeliveryData delivery_data { get; set; }
                public ShippingFeeData shipping_fee_data { get; set; }
            }

            public class AddCardUrl
            {
                public string ui { get; set; }
                public string version { get; set; }
            }

            public class AddToCartInfo
            {
                public bool is_added_to_cart { get; set; }
            }

            public class Bank
            {
                public string description { get; set; }
                public string bank_name { get; set; }
                public bool hide { get; set; }
                public long? be_channel_id { get; set; }
                public string disabled_reason { get; set; }
                public string deep_link { get; set; }
                public PopupConfirmationData popup_confirmation_data { get; set; }
                public string icon_label { get; set; }
                public SubDescriptionInfo sub_description_info { get; set; }
                public string info_link { get; set; }
                public string spm_extra_data { get; set; }
                public string option_info { get; set; }
                public bool enabled { get; set; }
                public string icon { get; set; }
                public string icon_background { get; set; }
                public long? handling_fee { get; set; }
            }

            public class BannerInfo
            {
                public string msg { get; set; }
                public string learn_more_msg { get; set; }
            }

            public class BuyerAddressData
            {
                public long? addressid { get; set; }
                public long? address_type { get; set; }
                public string tax_address { get; set; }
            }

            public class BuyerInfo
            {
                public object kyc_info { get; set; }
                public string checkout_email { get; set; }
            }

            public class BuyerServiceFeeInfo
            {
                public string learn_more_url { get; set; }
            }

            public class BuyerTxnFeeInfo
            {
                public string title { get; set; }
                public string description { get; set; }
                public string learn_more_url { get; set; }
            }

            public class Category
            {
                public List<long?> catids { get; set; }
            }
            public class Groups
            {
                public bool bank_account { get; set; }
                public bool bank_transfer { get; set; }
                public bool wallet { get; set; }
                public bool seabank { get; set; }
                public bool airpay { get; set; }
                public bool installment { get; set; }
                public bool spm_channel { get; set; }
                public bool immediate { get; set; }
                public bool general_card { get; set; }
                public bool cod { get; set; }
                public bool spl { get; set; }
                public bool maribank { get; set; }
                public bool credit_card { get; set; }
            }


            public class Channel
            {
                public string name_label { get; set; }
                public string icon_background { get; set; }
                public long? priority { get; set; }
                public string disabled_reason_learn_more_button_text { get; set; }
                public bool preselect_disabled { get; set; }
                public long? subcategory { get; set; }
                public string country { get; set; }
                public string currency { get; set; }
                public List<Promotion> promotions { get; set; }
                public bool checkout_exposure { get; set; }
                public long? channel_id { get; set; }
                public List<string> option_keys_name { get; set; }
                public long? category { get; set; }
                public string channel_provider { get; set; }
                public string ccb_link { get; set; }
                public bool always_show { get; set; }
                public string disabled_reason { get; set; }
                public string disabled_reason_title { get; set; }
                public string hint { get; set; }
                public SelectedChannelItem selected_channel_item { get; set; }
                public string disabled_reason_learn_more { get; set; }
                public long? wallet_balance { get; set; }
                public List<object> payment_channel_banners { get; set; }
                public bool is_new { get; set; }
                public string description { get; set; }
                public ExtraData extra_data { get; set; }
                public long? version { get; set; }
                public object flag { get; set; }
                public string spm_option_info { get; set; }
                public string payment_result_text { get; set; }
                public LinkedBankAccount linked_bank_account { get; set; }
                public string icon { get; set; }
                public string info_link { get; set; }
                public long? disabled_reason_key { get; set; }
                public string channel_blackbox { get; set; }
                public string display_message { get; set; }
                public string combined_reminder_text { get; set; }
                public string ccb_text { get; set; }
                public Groups groups { get; set; }
                public long? be_channel_id { get; set; }
                public bool has_wallet { get; set; }
                public bool enabled { get; set; }
                public ChannelBehavior channel_behavior { get; set; }
                public SubDescriptionInfo sub_description_info { get; set; }
                public string spm_extra_data { get; set; }
                public long? spm_channel_id { get; set; }
                public string name { get; set; }
                public string info_text { get; set; }
                public long? balance { get; set; }
                public bool? kyc_enforcement_needed { get; set; }
                public bool? pin_set_up_needed { get; set; }
                public bool? activation_needed { get; set; }
                public bool? topup_needed { get; set; }
                public bool? pin_reset_needed { get; set; }
                public long? channelid { get; set; }
                public List<Bank> banks { get; set; }
                public List<object> cards { get; set; }
                public List<object> payment_channel_hints { get; set; }
                public AddCardUrl add_card_url { get; set; }
                public List<object> installment_banks { get; set; }
                public bool? hide_add_card_button { get; set; }
                public string add_card_button_label { get; set; }
            }

            public class ChannelBehavior
            {
                public bool disable_instruction { get; set; }
                public bool disable_cancel { get; set; }
            }

            public class ChannelData
            {
                public long? address_type { get; set; }
                public long? channelid { get; set; }
                public bool cod_supported { get; set; }
                public bool enabled { get; set; }
                public long? is_mask_channel { get; set; }
                public string name { get; set; }
                public long? priority { get; set; }
                public string warning { get; set; }
                public string warning_msg { get; set; }
                public bool multi_address_validation_enabled { get; set; }
                public object invalid_address_ids { get; set; }
            }

            public class ChannelExclusiveInfo
            {
                public long? source_id { get; set; }
                public string token { get; set; }
                public bool is_live_stream { get; set; }
                public bool is_short_video { get; set; }
            }

            public class ChannelItemData
            {
                public string expiry_date { get; set; }
                public string logo_url { get; set; }
                public string bank_name { get; set; }
                public string card_number { get; set; }
                public long? bank_id { get; set; }
                public string agency_uen { get; set; }
                public string agency_shortname { get; set; }
                public string identifier { get; set; }
            }

            public class CheckoutPriceData
            {
                public long merchandise_subtotal { get; set; }
                public long? shipping_subtotal_before_discount { get; set; }
                public long? shipping_discount_subtotal { get; set; }
                public long? shipping_subtotal { get; set; }
                public long? tax_payable { get; set; }
                public long? tax_exemption { get; set; }
                public long? iof_amount { get; set; }
                public long? custom_tax_subtotal { get; set; }
                public object promocode_applied { get; set; }
                public object credit_card_promotion { get; set; }
                public object shopee_coins_redeemed { get; set; }
                public long? group_buy_discount { get; set; }
                public object bundle_deals_discount { get; set; }
                public object price_adjustment { get; set; }
                public long? buyer_txn_fee { get; set; }
                public long? buyer_service_fee { get; set; }
                public long? insurance_subtotal { get; set; }
                public long? insurance_before_discount_subtotal { get; set; }
                public long? insurance_discount_subtotal { get; set; }
                public long? vat_subtotal { get; set; }
                public long total_payable { get; set; }
            }

            public class ClientEventInfo
            {
                public bool is_platform_voucher_changed { get; set; }
                public bool is_fsv_changed { get; set; }
            }

            public class CodData
            {
                public bool cod_available { get; set; }
            }

            public class CoinInfo
            {
                public long? coin_offset { get; set; }
                public long? coin_used { get; set; }
                public long? coin_earn_by_voucher { get; set; }
                public long? coin_earn { get; set; }
            }

            public class DeliveryData
            {
                public string delay_message { get; set; }
                public object max_days { get; set; }
                public object min_days { get; set; }
                public DetailInfo detail_info { get; set; }
                public string display_mode { get; set; }
                public long? estimated_delivery_time_max { get; set; }
                public long? estimated_delivery_time_min { get; set; }
                public long? estimated_delivery_date_from { get; set; }
                public long? estimated_delivery_date_to { get; set; }
                public bool has_edt { get; set; }
                public bool is_cross_border { get; set; }
                public bool is_rapid_sla { get; set; }
                public bool is_shopee_24h { get; set; }
            }

            public class DetailInfo
            {
                public double apt { get; set; }
                public double cdt_max { get; set; }
                public double cdt_min { get; set; }
                public string edt_max_dt { get; set; }
                public string edt_min_dt { get; set; }
                public long? he_cdt { get; set; }
                public long? he_pt { get; set; }
            }

            public class DisabledCheckoutInfo
            {
                public string description { get; set; }
                public bool auto_popup { get; set; }
                public List<ErrorInfo> error_infos { get; set; }
            }

            public class DisplayInfo
            {
                public string info_text { get; set; }
                public string name { get; set; }
                public PromotionInfo promotion_info { get; set; }
                public long? version { get; set; }
                public string description { get; set; }
                public bool is_new { get; set; }
                public long? channel_id { get; set; }
                public string icon { get; set; }
                public string icon_background { get; set; }
                public string info_link { get; set; }
            }

            public class DropshippingInfo
            {
                public bool enabled { get; set; }
                public string name { get; set; }
                public string phone_number { get; set; }
            }

            public class ErrorInfo
            {
                public string error_action { get; set; }
                public string error_type { get; set; }
                public string message { get; set; }
            }

            public class ExtraData
            {
                public V1ChannelGroupingInfo v1_channel_grouping_info { get; set; }
                public string sub_description_1 { get; set; }
                public string sub_description_2 { get; set; }
                public long? expiry_extension { get; set; }
                public long? voucher_payment_type { get; set; }
                public string eligible_transfer { get; set; }
                public long? max_checkout_price { get; set; }
                public long? expiry_duration { get; set; }
                public long? min_amount { get; set; }
                public bool include_shipping_and_discounts { get; set; }
                public long? price_limit { get; set; }
                public List<long?> banned_categories { get; set; }
                public List<object> alternate_channel_ids { get; set; }
            }

            public class First
            {
                public string text { get; set; }
                public bool highlight { get; set; }
            }

            public class FreeShippingVoucherInfo
            {
                public long? free_shipping_voucher_id { get; set; }
                public string free_shipping_voucher_code { get; set; }
                public object disabled_reason { get; set; }
                public long? disabled_reason_code { get; set; }
                public BannerInfo banner_info { get; set; }
                public List<object> required_be_channel_ids { get; set; }
                public List<object> required_spm_channels { get; set; }
            }

            public class FulfillmentInfo
            {
                public long? fulfillment_flag { get; set; }
                public string fulfillment_source { get; set; }
                public bool managed_by_sbs { get; set; }
                public long? order_fulfillment_type { get; set; }
                public long? warehouse_address_id { get; set; }
                public bool is_from_overseas { get; set; }
            }

            public class Group
            {
                public long? group_id { get; set; }
                public List<long?> to_combine { get; set; }
                public DisplayInfo display_info { get; set; }
                public bool spm_channel { get; set; }
                public bool seabank { get; set; }
                public bool credit_card { get; set; }
                public bool wallet { get; set; }
                public bool bank_account { get; set; }
                public bool cod { get; set; }
                public bool immediate { get; set; }
                public bool installment { get; set; }
                public bool general_card { get; set; }
                public bool bank_transfer { get; set; }
                public bool maribank { get; set; }
                public bool airpay { get; set; }
                public bool spl { get; set; }
            }

            public class GroupingInfo
            {
                public List<Group> groups { get; set; }
                public string layout_format { get; set; }
            }

            public class Insurance
            {
                public string insurance_product_id { get; set; }
                public string name { get; set; }
                public string description { get; set; }
                public string product_detail_page_url { get; set; }
                public long? premium { get; set; }
                public long? premium_before_discount { get; set; }
                public long? insurance_quantity { get; set; }
                public bool selected { get; set; }
            }

            public class IofInfo
            {
                public string iof_msg { get; set; }
                public string learn_more_url { get; set; }
            }

            public class Item
            {
                public long itemid { get; set; }
                public long modelid { get; set; }
                public long? quantity { get; set; }
                public object item_group_id { get; set; }
                public List<Insurance> insurances { get; set; }
                public long? shopid { get; set; }
                public bool shippable { get; set; }
                public string non_shippable_err { get; set; }
                public string none_shippable_reason { get; set; }
                public string none_shippable_full_reason { get; set; }
                public long price { get; set; }
                public string name { get; set; }
                public string model_name { get; set; }
                public long? add_on_deal_id { get; set; }
                public bool is_add_on_sub_item { get; set; }
                public bool is_pre_order { get; set; }
                public bool is_streaming_price { get; set; }
                public string image { get; set; }
                public bool checkout { get; set; }
                public List<Category> categories { get; set; }
                public bool is_spl_zero_interest { get; set; }
                public bool is_prescription { get; set; }
                public ChannelExclusiveInfo channel_exclusive_info { get; set; }
                public long? offerid { get; set; }
                public bool supports_free_returns { get; set; }
            }

            public class LinkBankAccountPopup
            {
                public bool need_popup { get; set; }
                public string popup_message { get; set; }
                public string ok_button_message { get; set; }
                public string cancel_button_message { get; set; }
            }

            public class LinkedBankAccount
            {
                public bool @default { get; set; }
                public string bank_name { get; set; }
                public LinkBankAccountPopup link_bank_account_popup { get; set; }
                public bool is_expired { get; set; }
                public string verification_message { get; set; }
                public string disabled_reason { get; set; }
                public string disabled_reason_key { get; set; }
                public bool enabled { get; set; }
                public bool need_verification { get; set; }
                public string verification_url { get; set; }
                public bool is_linked { get; set; }
                public long? channel_item_id { get; set; }
                public string consent_token_display_number { get; set; }
                public string icon { get; set; }
                public string bank_account_number { get; set; }
                public string link_bank_account_url { get; set; }
            }

            public class LogisticChannels
            {
                [JsonProperty("8002")]
                public _8002 _8002 { get; set; }

                [JsonProperty("8003")]
                public _8003 _8003 { get; set; }

                [JsonProperty("8005")]
                public _8005 _8005 { get; set; }

                [JsonProperty("8006")]
                public _8006 _8006 { get; set; }

                [JsonProperty("80024")]
                public _80024 _80024 { get; set; }

                [JsonProperty("80055")]
                public _80055 _80055 { get; set; }

                [JsonProperty("80099")]
                public _80099 _80099 { get; set; }
            }

            public class Logistics
            {
                public List<long?> integrated_channelids { get; set; }
                public List<object> non_integrated_channelids { get; set; }
                public List<long?> voucher_wallet_checking_channel_ids { get; set; }
                public LogisticChannels logistic_channels { get; set; }
                public LogisticServiceTypes logistic_service_types { get; set; }
            }

            public class LogisticServiceTypes
            {
                public Regular regular { get; set; }
                public RegularCargo regular_cargo { get; set; }
                public SelfCollection self_collection { get; set; }
                public NextDay next_day { get; set; }
            }

            public class NextDay
            {
                public List<long?> channel_ids { get; set; }
                public bool enabled { get; set; }
                public string identifier { get; set; }
                public long? max_cost { get; set; }
                public long? min_cost { get; set; }
                public string name { get; set; }
                public long? priority { get; set; }
                public string sla_msg { get; set; }
            }

            public class OrderUpdateInfo
            {
            }

            public class PaymentChannelInfo
            {
                public List<Channel> channels { get; set; }
                public GroupingInfo grouping_info { get; set; }
                public PromotionInfo promotion_info { get; set; }
            }

            public class PopupConfirmationData
            {
                public bool need_popup { get; set; }
                public string popup_message { get; set; }
                public string ok_button_message { get; set; }
                public string cancel_button_message { get; set; }
            }

            public class PrescriptionInfo
            {
                public object images { get; set; }
                public bool required { get; set; }
                public long? max_allowed_images { get; set; }
            }

            public class Promotion
            {
                public bool is_fully_redeemed { get; set; }
                public long? start_time { get; set; }
                public string description { get; set; }
                public string url { get; set; }
                public string title { get; set; }
                public long? discount_type { get; set; }
                public long? end_time { get; set; }
                public string discount_value { get; set; }
                public long? card_promotion_id { get; set; }
                public string bank_logo { get; set; }
                public string primary_color { get; set; }
            }

            public class PromotionData
            {
                public bool can_use_coins { get; set; }
                public bool use_coins { get; set; }
                public List<object> platform_vouchers { get; set; }
                public FreeShippingVoucherInfo free_shipping_voucher_info { get; set; }
                public long? highlighted_platform_voucher_type { get; set; }
                public List<ShopVoucherEntrance> shop_voucher_entrances { get; set; }
                public object applied_voucher_code { get; set; }
                public object voucher_code { get; set; }
                public VoucherInfo voucher_info { get; set; }
                public string invalid_message { get; set; }
                public long? price_discount { get; set; }
                public CoinInfo coin_info { get; set; }
                public object card_promotion_id { get; set; }
                public bool card_promotion_enabled { get; set; }
                public string promotion_msg { get; set; }
            }

            public class PromotionInfo
            {
                public List<object> voucher_payment_type { get; set; }
                public long? voucher_payment_type_v2 { get; set; }
                public string text { get; set; }
                public long? text_type { get; set; }
            }

            public class Regular
            {
                public List<long?> channel_ids { get; set; }
                public bool enabled { get; set; }
                public string identifier { get; set; }
                public long max_cost { get; set; }
                public long? min_cost { get; set; }
                public string name { get; set; }
                public long? priority { get; set; }
                public string sla_msg { get; set; }
            }

            public class RegularCargo
            {
                public List<long?> channel_ids { get; set; }
                public bool enabled { get; set; }
                public string identifier { get; set; }
                public long max_cost { get; set; }
                public long min_cost { get; set; }
                public string name { get; set; }
                public long? priority { get; set; }
                public string sla_msg { get; set; }
            }

            public class Root
            {
                public long? client_id { get; set; }
                public long? cart_type { get; set; }
                public long? timestamp { get; set; }
                public CheckoutPriceData checkout_price_data { get; set; }
                public OrderUpdateInfo order_update_info { get; set; }
                public DropshippingInfo dropshipping_info { get; set; }
                public PromotionData promotion_data { get; set; }
                public SelectedPaymentChannelData selected_payment_channel_data { get; set; }
                public List<Shoporder> shoporders { get; set; }
                public List<ShippingOrder> shipping_orders { get; set; }
                public List<object> fsv_selection_infos { get; set; }
                public BuyerInfo buyer_info { get; set; }
                public ClientEventInfo client_event_info { get; set; }
                public PaymentChannelInfo payment_channel_info { get; set; }
                public BuyerTxnFeeInfo buyer_txn_fee_info { get; set; }
                public DisabledCheckoutInfo disabled_checkout_info { get; set; }
                public bool can_checkout { get; set; }
                public BuyerServiceFeeInfo buyer_service_fee_info { get; set; }
                public IofInfo iof_info { get; set; }
                public AddToCartInfo add_to_cart_info { get; set; }
            }

            public class Second
            {
                public string text { get; set; }
                public bool highlight { get; set; }
            }

            public class SelectedChannelItem
            {
                public long? error_code { get; set; }
                public string error_message { get; set; }
                public long? channel_item_id { get; set; }
                public ChannelItemData channel_item_data { get; set; }
            }

            public class SelectedPaymentChannelData
            {
                public string option_info { get; set; }
                public object text_info { get; set; }
            }

            public class SelfCollection
            {
                public List<long?> channel_ids { get; set; }
                public bool enabled { get; set; }
                public string identifier { get; set; }
                public long? max_cost { get; set; }
                public long? min_cost { get; set; }
                public string name { get; set; }
                public long? priority { get; set; }
                public string sla_msg { get; set; }
            }

            public class ShippingFeeData
            {
                public long? chargeable_shipping_fee { get; set; }
                public long? shipping_fee_before_discount { get; set; }
            }

            public class ShippingOrder
            {
                public long? shipping_id { get; set; }
                public List<long?> shoporder_indexes { get; set; }
                public long? selected_logistic_channelid { get; set; }
                public object buyer_remark { get; set; }
                public BuyerAddressData buyer_address_data { get; set; }
                public FulfillmentInfo fulfillment_info { get; set; }
                public Logistics logistics { get; set; }
                public long order_total { get; set; }
                public long order_total_without_shipping { get; set; }
                public object selected_logistic_channelid_with_warning { get; set; }
                public long? shipping_fee { get; set; }
                public long? shipping_fee_discount { get; set; }
                public string shipping_group_description { get; set; }
                public string shipping_group_icon { get; set; }
                public long? tax_payable { get; set; }
                public bool is_fsv_applied { get; set; }
                public long? shipping_discount_type { get; set; }
                public PrescriptionInfo prescription_info { get; set; }
                public long? iof_amount { get; set; }
            }

            public class Shop
            {
                public long? shopid { get; set; }
                public string shop_name { get; set; }
                public bool cb_option { get; set; }
                public bool is_official_shop { get; set; }
                public long? remark_type { get; set; }
                public bool support_ereceipt { get; set; }
                public long? shop_ereceipt_type { get; set; }
                public long? seller_user_id { get; set; }
                public long? shop_tag { get; set; }
            }

            public class Shoporder
            {
                public Shop shop { get; set; }
                public List<Item> items { get; set; }
                public TaxInfo tax_info { get; set; }
                public long? tax_payable { get; set; }
                public long? iof_amount { get; set; }
                public long? shipping_id { get; set; }
                public long? shipping_fee_discount { get; set; }
                public long? shipping_fee { get; set; }
                public long order_total_without_shipping { get; set; }
                public long order_total { get; set; }
                public object buyer_remark { get; set; }
            }

            public class ShopVoucherEntrance
            {
                public long? shopid { get; set; }
                public bool status { get; set; }
            }

            public class SubDescriptionInfo
            {
                public First first { get; set; }
                public Second second { get; set; }
                public string important { get; set; }
                public string normal { get; set; }
            }

            public class TaxInfo
            {
                public bool use_new_custom_tax_msg { get; set; }
                public string custom_tax_msg { get; set; }
                public string custom_tax_msg_short { get; set; }
                public bool remove_custom_tax_hint { get; set; }
                public string help_center_url { get; set; }
            }

            public class V1ChannelGroupingInfo
            {
                public string icon_background { get; set; }
                public long? group_id { get; set; }
                public long? version { get; set; }
                public List<object> channel_ids_to_combine { get; set; }
                public string channel_name { get; set; }
                public string icon_path { get; set; }
            }

            public class VoucherInfo
            {
                public long? coin_earned { get; set; }
                public object voucher_code { get; set; }
                public long? coin_percentage { get; set; }
                public long? discount_percentage { get; set; }
                public long? discount_value { get; set; }
                public long? promotionid { get; set; }
                public long? reward_type { get; set; }
                public long? used_price { get; set; }
            }


        }

    }
}
