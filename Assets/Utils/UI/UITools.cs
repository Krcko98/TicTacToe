using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Utils.UI
{
    public static class UITools
    {
        public static void LowestCommonTextSizeFromTMP(List<TextMeshProUGUI> text)
        {
            float lowestSize = text[0].fontSize;

            for(int i=0; i<text.Count ; i++)
            {
                if(text[i].fontSize < lowestSize)
                    lowestSize = text[i].fontSize;
            }

            foreach(TextMeshProUGUI tmp in text)
            {
                tmp.fontSize = lowestSize;
            }
        }
    }
}