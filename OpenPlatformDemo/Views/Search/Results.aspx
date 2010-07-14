<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Guardian.OpenPlatform.SearchResults>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Results
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Results</h2>

    <h2>Count: <%= Model.Count %></h2>
    
    <fieldset>
        <legend>Result count by content type:</legend>
    <% foreach (var item in OpenPlatformDemo.ResultsHelper.GetContentTypeCounts(Model.Results)){ %>
        <p>
            <%= Html.Encode(item.Key) %>: <%= Html.Encode(item.Value.ToString()) %>
            
        </p>
    <%} %>
    </fieldset>
    <% foreach (var item in Model.Results) { %>
    
    <fieldset>
        <legend>Fields</legend>
        <p>
            Publication:
            <%= Html.Encode(item.Publication) %>
        </p>
        <p>
            Headline:
            <%= Html.Encode(item.Headline)%>
        </p>
        <p>
            Standfirst:
            <%= Html.Encode(item.Standfirst) %>
        </p>
        <p>
            Byline:
            <%= Html.Encode(item.Byline) %>
        </p>
        <p>
            SectionName:
            <%= Html.Encode(item.SectionName) %>
        </p>
        <p>
            TrailText:
            <%= Html.Encode(item.TrailText) %>
        </p>
        <p>
            LinkText:
            <%= Html.Encode(item.LinkText) %>
        </p>
        <p>
            TrailImage:
            <%= Html.Encode(item.TrailImage) %>
        </p>
        <p>
            PublicationDate:
            <%= Html.Encode(String.Format("{0:g}", item.PublicationDate)) %>
        </p>
        <p>
            Id:
            <%= Html.Encode(item.Id) %>
        </p>
        <p>
            Type:
            <%= Html.Encode(item.Type) %>
        </p>
        
        <%if (item.Type == "article" ){%>
            <p>
                <%= item.TypeSpecific.Body %>    
            </p>
        <%} %>
        <p>
            <a href="<%= Html.Encode(item.WebUrl) %>">Web Url</a>
        </p>
        <p>
            <a href="<%= Html.Encode(item.ApiUrl) %>">Api Url</a>
        </p>
    </fieldset>    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

