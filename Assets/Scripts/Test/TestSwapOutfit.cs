using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.U2D.Animation;

public class TestSwapOutfit : MonoBehaviour
{
    //[SerializeField] private SpriteLibrary spriteLibrary;
    [SerializeField] private SpriteLibraryAsset spriteLibraryAsset;
    [SerializeField] private SpriteResolver hairResolver;
    [SerializeField] private SpriteResolver bodyResolver;
    //rivate SpriteLibraryAsset libraryAsset => spriteLibrary.spriteLibraryAsset;

    public void ChangeHeadOutFit(string label)
    {
            hairResolver.SetCategoryAndLabel("Hair", label);
    }

    public void ChangeBodyOutFit(string label)
    {
        bodyResolver.SetCategoryAndLabel("Body", label);
        
    }
}
