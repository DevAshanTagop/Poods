   M S B A M L   `   `   `  ���� @  <Poods, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PoodsPoods      Poods.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:Poods       � Icon$  
POODS1.ico�� � Title$ 
ПООДЗ�� � WindowStartupLocation$ CenterScreen=�$	��510��$	��900��$	��900��$	��510��.��� .+�� -    �Name$ AuthorizationGrid��$y�Visible=�.+��� -   $��Label1��$��Введите логин��$
��Left=�$��40��$��
148,46,0,0q�$	��Top=��� -   $��Label2��$!��Введите пароль��$
��Left=�$��43��$��148,150,0,0q�$	��Top=��� -   $��TextBoxLogin��$
��Left=�$��33��$	��250��$��
148,86,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�G� -   $��TextBoxPassword��$
��Left=�$��33��$	��250��$��148,190,0,0q�$	��Top=��� -   $��
Войти��$
��Left=�$��45��$��90��$��300,250,0,0q�$	��Top=�� -   $ MainManagmendGrid��
������$y�Visible=�$��9��.+�&   System.Windows.Controls.DataGrid  -     Name$ DataGridOrder��   AutoGenerateColumns .  $��10,34,142,61q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Номер заказа��	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *OrderNumber+  $ Дата заказа��
 �� *	DateOrder+  $ Статус оплаты��
 �� *Paid+  $ Статус заказа��
 �� *Status+  $/ )Отвественый сотрудник��$	 * 
 �� *	StaffInfo+  $" Номер ID клиента��$	 * 
 �� *
IdClient+  $% Полная стоимость��
 �� *	TotalCost+  $ Состав заказа��$	 * 
 �� *	Structure+�� -	   $��ClientsBaseWindow_Button��{�.  $c��]Открыть панель
управление базами
данных клиентов��$��	0,98,10,0q�$��Right=�$	��127��$��59��$	��Top=��� -
    ��Name$ CurrentUserInfo��$A��;Вы вошли как: Номер ID: Должность: ��$��14(�$
��Bold"�$��325,10,10,0q� �� TextAlignment$ Right=�$��19��$	��Top=��� -   $��
Выйти��$
��Left=�$��	10,0,0,10q�$��83��$��46��$��Bottom=��� -   $��StaffBaseWindow_Button��{�.  $g��aОткрыть панель
управление базами
данных сотрудников��$��	0,34,10,0q�$��59��$	��Top=�$��Right=�$	��127���� -   $��OrderBaseWindow_Button��{�.  $_��YОткрыть панель
управление базами
данных заказов��$��
0,162,10,0q�$��59��$	��Top=�$��Right=�$	��127���� -   $ ��CreationOrderWindow_Button��{�.  $��Создать заказ��$��	0,0,10,10q�$��46��$��Bottom=�$��Right=�$	��127���� -   $ CurrentOrderInfo��$<��6Количество активных заказов: ��$��10,10,580,0q�$
 Left=�$	��Top=�$��NoWrap=�$��14(�$
��Bold"��� -    ��Name$  FurnitureBaseWindow_Button��{�.  $]��WОткрыть панель
управление базами
данных мебели��$��
0,290,10,0q�$��Right=�$	��127��$��59��$	��Top=��� -   $/��)Перезагрузить таблицу��$��	98,0,0,10q�$��46��$��Bottom=�$
��Left=�$	��139���� -   $  MaterialsBaseWindow_Button��{�.  $e��_Открыть панель
управление базами
данных материалов��$��
0,354,10,0q�$��Right=�$	��127��$��59��$	��Top=��� -   $  ProvidersBaseWindow_Button��{�.  $g��aОткрыть панель
управление базами
данных поставшиков��$��
0,226,10,0q�$��Right=�$	��127��$��59��$	��Top=�