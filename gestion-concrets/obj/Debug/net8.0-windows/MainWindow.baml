   M S B A M L   `   `   `  ����K  Ggestion-concrets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:gestion_concretsgestion_concrets  5   	   !    gestion_concrets.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:gestion_concrets     5   	   M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5   	     � Title$   ��5	   	   $	��720��6   $
��1280��6   .��5
      � ���	#FF23232B$��Center=�6"   $	��709��6=    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��
300,0,10,0q�6   
�������$��1q�69    �� CornerRadius$ 30��6M   $��2��6_   
�������$	��684��6�   $��Center=�6�   $��1��6�   ._�5       � -   5          �Name$ 	MainFrame��5      $�� ��6'     � NavigationUIVisibility$ Hidden=�62   $��66,70,66,70q�6R   5        Wpf.Ui.Controls.Button  5   
   -   5          Name$ dashBt��5      $��Tableau de bord��6$   $
��Left=�6>   $��	25,68,0,0q�6Y   $��1��6l   $	��Top=�6y   $��43��6�   $	��249��6�   
�������$��14(�6�   $
��Bold"�6�   ��6�   Z� 6�     5   
   -   5        $ gestBt��5      $��Gestion des personnes��6$   $
��Left=�6D   $��
25,171,0,0q�6_   $��1��6s   $	��Top=�6�   $��43��6�   $	��249��6�   
�������$��14(�6�   $
��Bold"�6�   ��6�   Z� 6�     5   
   -   5        $ statBt��5      $��Statistiques��6$   $
��Left=�6;   $��
25,233,0,0q�6V   $��1��6j   $	��Top=�6w   $��43��6�   $	��249��6�   
�������$��14(�6�   $
��Bold"�6�   ��6�   Z� 6�     5   
   -   5        $
 bdBt��5      $��Base de données��6"   $
��Left=�6<   $��
25,293,0,0q�6W   $��1��6k   $	��Top=�6x   $��43��6�   $	��249��6�   
�������$��14(�6�   $
��Bold"�6�   ��6�   Z� 6�     5   
   -   5        $ aideBt��5      $��Aide ��6$   $
��Left=�64   $��
25,352,0,0q�6O   $��1��6c   $	��Top=�6p   $��43��6�   $	��249��6�   
�������$��14(�6�   $
��Bold"�6�   ��6�   Z� 6�   5      5       