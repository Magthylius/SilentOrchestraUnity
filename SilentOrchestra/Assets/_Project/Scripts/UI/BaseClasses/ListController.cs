using System.Collections;
using System.Collections.Generic;
using Magthylius;
using UnityEngine;

namespace SilentOrchestra.UI
{
    public class ListController : MonoBehaviour
    {
        [Header("List Item Controller")] 
        [SerializeField] private ListItem listItemPrefab;
        [SerializeField] private Transform contentTransform;
        [SerializeField] private bool clearItemsOnInitialize = true;

        protected List<ListItem> Items = new List<ListItem>();

        public virtual void Initialize()
        {
            if (clearItemsOnInitialize) ClearContent();
        }
        
        public virtual void ClearContent()
        {
            contentTransform.DestroyChildren();
            Items.Clear();
        }
        
        public virtual ListItem AddItem()
        {
            ListItem item = Instantiate(listItemPrefab, contentTransform);
            item.Initialize(this);
            Items.Add(item);
            return item;
        }

        public virtual bool RemoveItem(ListItem item)
        {
            ListItem itemToDestroy = null;
            foreach (ListItem listItem in Items)
            {
                if (listItem == item) itemToDestroy = listItem;
            }

            if (!itemToDestroy) return false;
            
            item.Deinitialize();
            Items.Remove(itemToDestroy);
            Destroy(itemToDestroy);
            return true;
        }
    }
}
