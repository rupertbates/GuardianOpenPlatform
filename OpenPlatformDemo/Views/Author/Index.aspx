<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Dictionary<string, int>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <% ChartHelper.PopulateChart(Chart1, Model); %>
    <asp:CHART id="Chart1" runat="server" Height="296px" Width="812px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#D3DFF0" Palette="BrightPastel" BorderDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
		<legends>
			<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
		</legends>
		<borderskin SkinStyle="Emboss"></borderskin>
		<series>
			<asp:Series XValueType="string" Name="Series1" IsValueShownAsLabel="true" ChartType="Spline" IsXValueIndexed="true" BorderColor="180, 26, 59, 105" YValueType="Int32"></asp:Series>
		</series>
		<chartareas>
			<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
				<area3dstyle Rotation="9" Perspective="10" Enable3D="True" LightStyle="Realistic" Inclination="38" PointDepth="200" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
				<position Y="2" Height="94" Width="94" X="2"></position>
				<axisy LineColor="64, 64, 64, 64">
					<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
					<MajorGrid LineColor="64, 64, 64, 64" />
				</axisy>
				<axisx LineColor="64, 64, 64, 64">
					<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
					<MajorGrid LineColor="64, 64, 64, 64" />
				</axisx>
			</asp:ChartArea>
		</chartareas>
	</asp:CHART>
</asp:Content>
