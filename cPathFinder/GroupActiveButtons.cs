using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace cPathFinder
{
    class GroupActiveButtons
    {
        private List<Button> buttonActives;
        public Button CurrentActive { get; set; }
        public GroupActiveButtons()
        {
            buttonActives = new List<Button>();
            
        }
        public void addToGroup(Button btn)
        {
            buttonActives.Add(btn);
        }

        public System.Collections.Generic.IEnumerator<Button> GetEnumerator()
        {
            foreach (var elem in buttonActives)
            {
                yield return elem;
            }
        }
        public void setButtonToActiveOrDeactive(Button btn)
        {
            if (buttonActives.Contains(btn))
            {
                if (CurrentActive == null || CurrentActive!=btn)
                {
                    CurrentActive = btn;
                }
                else
                {
                    CurrentActive = null;
                }
            }
        }

        
    }
}
