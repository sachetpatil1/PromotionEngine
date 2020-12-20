using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    class Promotion
    {
        Dictionary<string, int> SKUIDs = new Dictionary<string, int>();

        string[] PromotionOffer = {"A$3:130","B$2:45","C$1-D$1:30"};
        
        public Promotion()
        {
            SKUIDs.Add("A", 50);
            SKUIDs.Add("B", 30);
            SKUIDs.Add("C", 20);
            SKUIDs.Add("D", 15);
        }

        public int GetCartPrice(Dictionary<string,int> CartDetails)
        {
            int TotalPrice = 0;
            int OfferPrice = 0;
            int resPrice = 0;

            foreach (var item in CartDetails)
            {
                int remQty = 0;
                int totalQty = item.Value;
                int offerTime = 0;
                int OfferQty = 0;
                foreach (string offer in PromotionOffer)
                {
                    string offerItem = offer.Split(':')[0];
                    int offerValue = Convert.ToInt16(offer.Split(':')[1]);
                    offerTime = 0;
                    resPrice = 0;

                    foreach (string offerProductItem in offerItem.Split('-'))
                    {
                        string offerProduct = offerProductItem.Split('$')[0];
                        int offerProductQty = Convert.ToInt16(offerProductItem.Split('$')[1]);
                        
                        if (item.Key == offerProduct)
                        {
                            remQty = item.Value;
                            while (remQty >= offerProductQty)
                            {
                                remQty = remQty - offerProductQty;
                                offerTime = offerTime + 1;
                                OfferQty = OfferQty + offerProductQty;
                            }
                            resPrice = resPrice + (SKUIDs[item.Key] * OfferQty);
                        }
                        else
                        {
                            if (offerTime > 0)
                            {
                                offerTime = offerTime - 1;
                                if (remQty == 0)
                                {
                                    TotalPrice = TotalPrice + resPrice;
                                }
                            }
                        }

                    }

                    OfferPrice = OfferPrice + (offerValue * offerTime);
                    
                }

                TotalPrice = TotalPrice + (SKUIDs[item.Key] * remQty);
                
            }

            return TotalPrice + OfferPrice;
        }
        
    }
}
