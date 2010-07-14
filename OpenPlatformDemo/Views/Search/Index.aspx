<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Guardian.OpenPlatform.ContentSearchParameters>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm("Results", "Search")){%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Query">Query:</label>
                <%= Html.TextBox("Query") %>
                <%= Html.ValidationMessage("Query", "*") %>
            </p>
            <p>
                <label for="After">After:</label>
                <%= Html.TextBox("After") %>
                <%= Html.ValidationMessage("After", "*") %>
            </p>
            <p>
                <label for="Before">Before:</label>
                <%= Html.TextBox("Before") %>
                <%= Html.ValidationMessage("Before", "*") %>
            </p>
            <p>
                <label for="ContentType">ContentType:</label>
                <%= Html.TextBox("ContentType") %>
                <%= Html.ValidationMessage("ContentType", "*") %>
            </p>
            <p>
                <label for="Count">Count:</label>
                <%= Html.TextBox("Count") %>
                <%= Html.ValidationMessage("Count", "*") %>
            </p>
            <p>
                <label for="StartIndex">StartIndex:</label>
                <%= Html.TextBox("StartIndex") %>
                <%= Html.ValidationMessage("StartIndex", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

