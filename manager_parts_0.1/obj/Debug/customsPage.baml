   M S B A M L   `   `   `  ����L  Hmanager_parts_0.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:manager_parts_0._1manager_parts_0._1  5      $    manager_parts_0._1.customsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:manager_parts_0._1     5      -   5          N� Title$  customsPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��350 �6   �� 5      $	��120 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ customsPAGE��5      $��0,11,-0.2,10.4q�6(    J� RenderTransformOrigin$ 0.5,0.5&�6@      AutoGenerateColumns .     
IsReadOnly . $��2��6�   $��Right=�6�   $
��1313��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.258Q�6&   T� 5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$# Дата_реєстрації��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6b   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6>   �� *Дата_реєстрації+6n     5      $ Код_товару��6%   $	 * 6Y   
 69   �� *Код_товару+6e     5       $! Код_працівника��6%   $	 * 6a   
 6=   �� *Код_працівника+6m     5!      $< 6Відцоток_додаткової_вартості��6%   $	 * 6|   
 6K   �� *86Відцоток_додаткової_вартості+6�     5"      $ Кількість��6%   $	 * 6V   
 68   �� *Кількість+6b     5$      $, &Строк_зберігання_СТЗ��6%   $	 * 6m   
 6C   �� *(&Строк_зберігання_СТЗ+6y     5%      $ Номер_рахунку��6%   $	 * 6^   
 6<   �� *Номер_рахунку+6j     5&      $ Cтатус��6%   $	 * 6P   
 65   �� *Cтатус+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5)      $
	 auto 6)      CellTemplate 5*      �� 5+      .R�5,      �� $��BtnEdit��6;   -   5        $��Редагуваати��5,   %   6c   5-      5/      51      �� 52   
   -   5        $��BtnAdd��52   ?   $��Додати��6   $
��Left=�6$   $��55,24.6,0,45.4q�6b   $��98��6z   $��1��6�   �� 53   
   -   5        $��	BtnDelete��53   @   $��Видалити��6   $��Right=�6$   $��0,35.6,67,34.4q�6i   $��98��6�   $��1��6�   �� 54   
   $��
Пошук��6   $��388,9.8,520,92q�6!   $��1��69   �� 55   
   -   5        $��customsList��55      $��30��6&   $	��Top=�62   $��249,66.8,457,0q�6z   $��1��6�   .@�56      �� .��6   Дата_реєстрації6,   �� 57      .��6   Код_працівника6+   �� 58      .��6   Номер_рахунку6*   �� 59      .��6   Cтатус6#   �� 5:      .��6   Код_товару6'   5=      �� 5>   
   -   5        $��searchValue��5>   b   $��245,27.6,460.8,59.4q�6   $��1��6/   $ 0.496,0.469&�6<   6b   �� 5?   
   -   5        $��
btn_search��5?   L   $��900,22.6,277.8,65.4q�6   $��1��6.   $��Знайти��6;   6^   �� 5@   
   -	   5        $��btn_reaload��5@   M   $��900,66.6,277.8,21.4q�6   $��1��6.   $��Оновити��6;   6`   �� 5A   
   -
   5        $��gotoMainpage��5A   '   $��На головну��6   $��180,24.6,1089.8,54.4q�6V   $��1��6t   5C      5D      