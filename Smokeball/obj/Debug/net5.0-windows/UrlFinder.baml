   M S B A M L   `   `   `  ����D  @Smokeball, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Smokeball	Smokeball  5   	       Smokeball.UrlFinder   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Smokeball     5   	     � Title$  	UrlFinder��5   	   $	��380��6   $	��800��6(    � 
ResizeMode$ NoResize=�64   .��5	      � .+�5
   
   �� $��Center=�6   $	��318��61   
���   �$��Center=�6M   $	��762��6h   �� 5   
   -   5         ��Name$ lbl_app_name��5      $��Smokeball Url Finder��6&   $
��Left=�6E   $��28��6`   $��
306,23,0,0q�6l   $	��Top=�6�   $	��196��6�   $��Arial Rounded MT Bold)�6�   $��18(�6�   �� 5   
   -   5        $ lbl_search_keywords��5      $��Search Keywords��6-   $
��Left=�6G   $��	86,85,0,0q�6b   $	��Top=�6u   �� 5   
   -   5        $ lbl_url��5      $	��Url��6!   $
��Left=�6/   $��160,147,0,0q�6J   $	��Top=�6_    J� RenderTransformOrigin$ 0.776,-0.692&�6w   �� 5   
   -   5         ��Name$ txt_search_keywords��5      $
��Left=�5      $��30��5      $��
207,83,0,0q�5       �� TextWrapping$
 Wrap=�5      $	��Top=�5      $	��473��5      ��5      �� *SearchKeywords+ �� UpdateSourceTrigger$ PropertyChanged=�" �� ValidatesOnNotifyDataErrors$
 True��.��5       =� ErrorTemplate 5      �� 5      .R�5      �� .+�5      �� 	 ��Name$	 textBox��64   �� 5      ��6'   �� ��5      �� 5   "   .R�5   &   �� 
���  ����60   �� *ErrorContent+6N   5   #   5!      5"      5#      .��5$   (   5%      �� 5&   
   -   5        $ txt_url��5&      $
��Left=�5(      $��207,143,0,0q�5)      $
 Wrap=�5*      $	��Top=�5+      $	��473��5,      $��30��5-      ��5'      �� *Url+$ PropertyChanged=�$
 True��.��5-       5.      �� 5/      .R�50      �� .+�52      �� $	 textBox��64   �� 53      ��6'   �� ��54      �� 55   "   .R�56   &   �� 
���  ����60   �� *ErrorContent+6N   57   #   59      5:      5;      .��5<   (   5=      �� 5>   
   -   5        
 ��Name$
 
btn_search��5>      $��Search��5?      $
��Left=�5@      $	��231��5A      $��30��5B      $��207,208,0,0q�5C      $	��Top=�5D      5F      �� 5G   
   -   5        $
 	btn_reset��5G      $��Reset��5H      $
��Left=�5I      $	��231��5J      $��30��5K      $��449,208,0,0q�5L      $	��Top=�5M      $ 1.351,0.568&�6)   5N      �� 5O   
   -   5         ��Name$ txt_message_block��5O      $��267,269,190,0q�6/   $��Bahnschrift SemiBold)�6F   $��16(�6h   $��29��6v   $	��Top=�6�   5P      5Q      