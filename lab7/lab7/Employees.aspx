﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="lab7.Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <br />
<table border="0">
    <tr>
    <td>
    <asp:Label ID="LabelFindEmployee" runat="server" Text="Имя сотрудника"></asp:Label><asp:TextBox ID="TextBoxFindEmployee" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonFindEmployee" runat="server" Text="Найти" OnClick="ButtonFindEmployee_Click" />
    <br />        
        <asp:GridView ID="GridViewEmployee" runat="server" AutoGenerateColumns="False"
            AllowPaging="True" 
            AutoGenerateDeleteButton="True" 
            AutoGenerateEditButton="True" 
            OnRowCancelingEdit="GridViewEmployee_RowCancelingEdit" 
            OnRowDeleting="GridViewEmployee_RowDeleting" 
            OnRowEditing="GridViewEmployee_RowEditing" 
            OnRowUpdating="GridViewEmployee_RowUpdating" PageSize="15" 
            OnPageIndexChanging="GridViewEmployee_PageIndexChanging"
            Caption="Сотрудники" 
            EmptyDataText="Нет данных" CaptionAlign="Top" PageIndex="0">
            <Columns>
                <asp:BoundField DataField="EmployeeId" HeaderText="Код" SortExpression="EmployeeId" />
                <asp:BoundField DataField="Surname" HeaderText="Фамилия" SortExpression="Surname" />
                <asp:BoundField DataField="Name" HeaderText="Имя" SortExpression="Name" />
                <asp:BoundField DataField="Patronymic" HeaderText="Отчество" SortExpression="Patronymic" />
                <asp:BoundField DataField="Post" HeaderText="Должность" SortExpression="Post" />
                <asp:BoundField DataField="EmploymentDate" HeaderText="Дата трудоустройства" SortExpression="EmploymentDate" />
            </Columns>
            
    </asp:GridView>
        </td>
        <td>
        <strong>Добавить нового сотрудника:</strong>
            <br />
            <asp:label runat="server">Фамилия:</asp:label><asp:TextBox ID="TextBoxEmployeeSurname" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Имя:</asp:label><asp:TextBox ID="TextBoxEmployeeName" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Отчество:</asp:label><asp:TextBox ID="TextBoxEmployeePatronymic" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Должность:</asp:label><asp:TextBox ID="TextBoxEmployeePost" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server" ID="label1">Дата трудоустройства:</asp:label><asp:TextBox ID="TextBoxEmployeeEmploymentDate" runat="server"></asp:TextBox>
            <br />
        </td>
        <td>
            <asp:Button ID="ButtonAddEmployee" runat="server" Text="Добавить" OnClick="ButtonAddEmployee_Click" />

        </td>
</tr>
</table>
    </asp:Content>