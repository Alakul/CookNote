   M S B A M L   `   `   `  ����C  ?CookNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CookNote.PagesCookNote.Pages  5           CookNote.Pages.RecipesList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:CookNote.Pages     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   ��  
  Border#��[  6     PrimaryBrush#��[ 61    �� Padding$ 20,10,20,10q�6\   $��0��6r   $��2��6   ._�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $��* �6'   63   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6-   .+�5      �� -   5        $ 0,0,10,0q�5      #��[ 60   ._�5      F� -   5         F�Name$ backPath��5        BackPath#��[ 61   $
��Left=�6S   5      �� 5        TextBlockMenu#��[ 6     �� Padding$ 6,0,6,0q�6G   LISTA PRZEPISÓW6j   5      �� 5      $��1��6   $ 
Horizontal=�6-   $��Right=�6F   .+�5      �� -   5          
ButtonMenu#��[ 5      .��6Y   DODAJ PRZEPIS6h   5       5!      5"      �� 5$   
     
StackPanel#��[ 6   $��1��69   .+�5%      �  5&      �� 5'      $
��auto �6'   66   �� 5(      $��2* �6'   64   �� 5)      $��* �6'   63   �� 5*      $
��auto �6'   66   �� 5+      $��* �6'   63   �� 5,      $��* �6'   63   �� 5-      $
��auto �6'   66   �� 5.      $��* �6'   63   �� 5/      $
��auto �6'   66   �� 50      $��2* �6'   64   .+�53      ��   TextBlockHorizontal#��[ 6   $��Right=�6I   $��0��6e   	Kategoria6�   �� 54      -   5         ��Name$ category��54        ComboBoxTemplate#��[ 6-     ComboBoxItem#��[ 6Z   $��1��6�   6�   �� 56      #��[ 6   $��Right=�6I   $��3��6e   
Wyszukaj6   �� 57      -   5         ��Name$ search��57       	 TextBoxStyle#��[	 6*   $��4��6P   $��2��6`   6v   �� 58      -   5         

 Button#��[
 58      $��6��6X   .��59      F� -   5        $ 
searchPath��59        
SearchPath#��[ 6/   5:      �� 5<      #��[ 6   $��Right=�6I   $��8��6e   Sortuj6}   �� 5=      -   5        $
 sort��5=      #��[ 6)   #��[ 6V   $��9��6�   5>      5?      �� 5A   
   $ 
10,0,10,20q�6   $��2��6&   ._�5B      �� -	   5         ��Name$ recipesList��5B      $	��415��6,     ListViewItemStyle#��[ 69   $��Stretch=�6�   	 �� SelectedItem	 6q   �� *Id+��6�   �� ��5C      �� 5D      .R�5E      �  5F      �� 5G   "   $��* �63   6?   �� 5H   "   $��* �63   6?   .+�5K      �� $ 
Horizontal=�6)   $��Center=�6B   $��Stretch=�6]   $��0��6{   .+�5L   "   �� $��14(�6,   $ 	10,6,10,6q�6:   ��6N   �� *Title+5M      �� 5N      $ 
Horizontal=�6)   $��Right=�6B   $��1��6^   .+�5O   "   �� 
 ��Name$
 
editRecipe��6)   -
   5          
ButtonList#��[ 5O   =   $��Edytuj��6t   �� 5P   "   $
 deleteFromList��6)   -   5        #��[ 5P   A   $��Usuń��6z   5Q      5R      5S      5U      5V      5W      5X      