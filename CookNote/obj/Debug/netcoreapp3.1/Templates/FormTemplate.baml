   M S B A M L   `   `   `  ����C  ?CookNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CookNote.ValidationRulesCookNote.ValidationRules  5      %    CookNote.Templates.FormTemplate   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5vr&clr-namespace:CookNote.ValidationRules     5      .��5	      � .+�5
   
   ��  
  Border#��[  6   $��1��61   ._�5      �� -   5          ��Name$  scrollViewer��5      $	��450��61   $
��Auto=�6>   .��5      �  � RowDefinitions 5      �� 5      $
��auto �6(   68   �� 5      $��* �6(   65   �� 5      $
��auto �6(   68    � ColumnDefinitions 5      �� 5      $��* �6+   67   �� 5      $��* �6+   67   .+�5      ��  �� Orientation$ Vertical=�6!   $��0,0,10,0q�68   $��0��6J   $��0��6Z   .+�5      ��   
StackPanel#��[ 6%   .+�5      ��   TextBlockHeader#��[ 6(   Tytuł6X   �� 5      -   5         ��Name$ title��5   &     TextBoxInError#��[ 65   .��6]   ��5   "   �� 5   &    �� Path$ Title�6.    �� ValidatesOnDataErrors$
 True��6;    �� UpdateSourceTrigger$ PropertyChanged=�6X    �� ValidationRules 5   *   1  +CookNote.ValidationRules.TextValidationRule  5   .   	   MinSize$	 1��6D   
   MaxSize$	
 100��6P      Message$; 5Liczba znaków powinna zawierać się w przedziale od��6^   5    '   .��5!   0   5"      5#      �� 5$      #��[ 6%   .+�5%      �� #��[ 6(   Opis6W   �� 5&      -   5        $ description��5&   &   $	��100��6;     TextBoxStyle#��[ 6H    �� TextWrapping$
 Wrap=�6n    �� AcceptsReturn$
 True��6�   " �� VerticalScrollBarVisibility$ Visible=�6�   .��6�   ��5'   "   �� 5(   &   $ Description�6.   $
 True��6A   $ PropertyChanged=�6^    5)   *     5*   .   $	 0��6D   $

 5000��6P   $; 5Liczba znaków powinna zawierać się w przedziale od��6_   5,   '   .��5-   0   5.      5/      �� 50      #��[ 6%   .+�51      �� #��[ 6(   	Kategoria6\   �� 52      -   5         ��Name$ category��52   '     ComboBoxTemplate#��[ 69     ComboBoxItem#��[ 6f   6�   53      54      �� 56      $��10,0,0,0q�6!   $��1��63   .+�57      �� #��[ 6%   .+�58      �� #��[ 6(   Obraz6X   � 59       5:   "   �� 5;   &   $
��auto �67   6F   �� 5<   &   $��* �67   6C   �� 5=   &   $
��auto �67   6F    5@   "   �� 5A   &   $
��auto �64   6D   �� 5B   &   $
��auto �64   6D   .+�5E   "   �� -   5         
 Button#��[ 5E   )   $��0��6b   .��6r   	WYBIERZ6{   �� 5F   "   $��1��6)     BorderTextBox#��[ 69   ._�5G   &   �� -   5         ��Name$
 file��5G   0   6@   5H   #   �� 5I   "   -   5        #��[ 5I   )   $��2��6b   .��6r   USUŃ6x   �� 5K   "   -   5         ��Name$ image��5K   (   $��0��67   $��1��6G   $��3��6T   $��0,10,0,0q�6h   $	��200��6z   5L      5M      5N      �� 5P      $��0,0,10,0q�6!   $��1��63   $��0��6@   .+�5Q      �� #��[ 6%   .+�5R      �� #��[ 6(   
Składniki6\   �� 5S      -	   5        $ ingredients��5S   &   $	��150��6;   #��[ 6H   $
 Wrap=�6p   $
 True��6�   $ Visible=�6�   .��6�   ��5T   "   �� 5U   &   $ Ingredients�6.   $
 True��6A   $ PropertyChanged=�6^    5V   *     5W   .   $	 1��6D   $
 10000��6P   $; 5Liczba znaków powinna zawierać się w przedziale od��6`   5Y   '   .��5Z   0   5[      5\      5]      �� 5_      $��10,0,0,0q�6!   $��1��63   $��1��6@   $��2��6P   .+�5`      �� #��[ 6%   .+�5a      �� #��[ 6(   Przygotowanie6`   �� 5b      -
   5        $ method��5b   &   $	��150��66   #��[ 6C   $
 Wrap=�6k   $
 True��6   $ Visible=�6�   .��6�   ��5c   "   �� 5d   &   $ Method�6.   $
 True��6<   $ PropertyChanged=�6Y    5e   *     5f   .   $	 1��6D   $
 10000��6P   $; 5Liczba znaków powinna zawierać się w przedziale od��6`   5h   '   .��5i   0   5j      5k      5l      �� 5n      #��[ 6!   $��2��6E   $��0��6R   $��2��6b   .+�5o      �� -   5         ��Name$ actionButton��5o   !   $��DODAJ PRZEPIS��67   $��Center=�6j   ��5p      �� 5q   "    �� BasedOn# [ 6(    �� 
TargetType" ��6J   .�5r   &   ��  �� Property � �� �� Value$ 13(�6A   �� 5s   &    � {�$ false��6B    �� Triggers 5t   &   ^� 5u   *    ^� 
Conditions 5v   .   �� 5w   2    �� Binding 6<   ��  �� ElementName$ title��$ (Validation.HasError)� �� Value	 false6~   �� 5x   2    6<   �� $ ingredients��$ (Validation.HasError)�	 false6�   �� 5y   2    6<   �� $ method��$ (Validation.HasError)�	 false6   .0�5{   .   ��  � {�$
 true��6J   5|   +   5~   #   5�      5�      5�      5�      5�      5�      5�      