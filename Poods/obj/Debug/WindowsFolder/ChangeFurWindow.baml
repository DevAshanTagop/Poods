   M S B A M L   `   `   `  ����@  <Poods, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Poods.WindowsFolderPoods.WindowsFolder  5   	   )    #Poods.WindowsFolder.ChangeFurWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Poods.WindowsFolder     5   	     � Title$  Выбор мебели��5   	   $	��600��6   $	��800��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��5q�6;   .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��200��6-   $��5q�69   $ ��Поиск мебели...��5      
�������5      �� 5      -   5        $��Обновить��5      $��5q�6(   $
��10,5q�63    � ToolTip$0 *Обновить список мебели��5   1   5      �� 5   
   $��1��6   .��5      � -   5         �Name$ FurnitureButtonsPanel��5      $��10q�67   5      �� 5!   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��5q�6W   .+�5"      �� -   5         ��Name$ SelectedCountText��5"      $��5q�63   $��Center=�6>   �� 5#      -   5        $��ConfirmButton��5#      $'��!Подтвердить выбор��6*   $
��10,5q�6F   $��5q�6U   5$      5%      5&      5'      