<%@ Page Title="" Language="C#" MasterPageFile="~/Login/MasterPage.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Login_Main" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <div class="row">
    <div class="col-md-12">
        <section id="loginForm">
           <div class="form-horizontal">
               <h4>Bienvenido</h4>
               
               <hr />
                    <div class="row">
                            <div class="col-lg-12 ">
                              
                    
                                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  DataKeyNames="IDE_USUARIO,IdSistema,IdPerfil,Descripcion,DES_NOMBRE_USUARIO,UrlDefault,NOMBRE_CORTO,PERFIL_NAME" OnRowDataBound="GridView1_RowDataBound" CssClass="table table-striped table-bordered table-hover">
                                     <Columns>
                                         <asp:BoundField DataField="Row" HeaderText="N°" SortExpression="Row" />
                                         <asp:BoundField DataField="SISTEMAS" HeaderText="Sistema" SortExpression="SISTEMAS" />
                                         
                                  
                                         <asp:TemplateField>
                                             <ItemTemplate>
                                                 <center>

                                              
                                                 <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="Images/Pencil.png" OnClick ="Seleccionar" CommandArgument='<%# Eval("Row") %>' />
                                                </center>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>
                                          
                                 </asp:GridView>

                                
                               
                            </div>
                       </div> 
             </div>
           </section>
        </div>
            

   </div>

</asp:Content>

