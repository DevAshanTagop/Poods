   M S B A M L   `   `   `  ���� @  <Poods, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Poods.WindowsFolderPoods.WindowsFolder  )    #Poods.WindowsFolder.OrderBaseWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:Poods.WindowsFolder       � Title$P  JПанель управление базами данных заказов�� � WindowStartupLocation$ CenterScreen=�$	��450��$
��1100��$
��1100��$	��450��.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ DataGridOrder��   AutoGenerateColumns .  $��10,10,10,115q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$  Номер ID заказа��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	IdOrder+  $ Номер заказа��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *  �� *OrderNumber+  $ Дата заказа�� �� *	DateOrder+  $# Дата завершения�� �� *CompletionDate+  $ Статус оплаты�� �� *Paid+  $ Статус заказа�� �� *Status+  $/ )Отвественый сотрудник�� �� *	StaffInfo+  $" Номер ID клиента�� �� *
IdClient+  $% Полная стоимость�� �� *	TotalCost+  $ Состав заказа��$ *  �� *	Structure+�� -   $��Обновить��$��
144,0,0,10q�$��33��$��Bottom=�$
��Left=�$��92���� $
��Left=�$��
107,0,0,94q�$
��Wrap=�$��Bottom=�$	��189��$��Статус оплаты���� -   $��Удалить��$
��Left=�$��
241,0,0,10q� J� RenderTransformOrigin$ 0.454,0.102&�$��92��$��33��$��Bottom=��� -   $��ComboBoxIdOrder��$
��Left=�$��	10,0,0,48q�$��92��$��41��$��Bottom=��� $
��Left=�$��	10,0,0,94q�$
��Wrap=�$ ��Номер ID заказа��$��Bottom=�$��92��$ 0.282,0.624&��� -   $��ComboBoxPaidStatus��$
��Left=�$��
107,0,0,48q�$	��189��$��41��$��Bottom=��� -   $��ComboBoxStatusOfOrder��$
��Left=�$��
301,0,0,48q�$	��185��$��41��$��Bottom=��� $
��Left=�$��
301,0,0,94q�$
��Wrap=�$	��185��$��16��$��Bottom=�$��Статус заказа���� -   $/��)Перезагрузить таблицу��$
��Left=�$��
338,0,0,10q�$ 0.454,0.102&�$	��137��$��33��$��Bottom=��� -   $#��Добавить мебель��$��	10,0,0,10q�$��33��$��Bottom=�$
��Left=�$	��129��