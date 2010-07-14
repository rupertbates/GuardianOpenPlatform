<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MusicModel>>" %>
<%@ Import Namespace="OpenPlatformDemo.Models.Music" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Music type by day</h2>
    <% ChartHelper.PopulateChart(Chart1, Model); %>
    <asp:CHART id="Chart1" runat="server" Height="296px" 
    Width="812px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" 
    ImageType="Png" BackColor="#D3DFF0" Palette="BrightPastel" 
    BorderDashStyle="Solid" BackSecondaryColor="White" 
    BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
		<borderskin SkinStyle="Emboss"></borderskin>
		<series>
			<asp:Series XValueType="string" LegendText="Pop and Rock" Name="PopAndRock" IsValueShownAsLabel="true" Color="Red" ChartType="Spline" BorderWidth="2" IsXValueIndexed="true" BorderColor="180, 26, 59, 105" YValueType="Int32"></asp:Series>
			<asp:Series XValueType="string" Name="Classical" IsValueShownAsLabel="true" Color="Green" ChartType="Spline" IsXValueIndexed="true" BorderWidth="2" BorderColor="180, 26, 59, 105" YValueType="Int32"></asp:Series>
			<asp:Series XValueType="string" Name="Electronic" IsValueShownAsLabel="true" Color="Beige" ChartType="Spline" IsXValueIndexed="true" BorderWidth="2" BorderColor="180, 26, 59, 105" YValueType="Int32"></asp:Series>
			<asp:Series XValueType="string" Name="Urban" IsValueShownAsLabel="true" Color="BurlyWood" ChartType="Spline" IsXValueIndexed="true" BorderWidth="2" BorderColor="180, 26, 59, 105" YValueType="Int32"></asp:Series>
			<asp:Series XValueType="string" Name="Folk" IsValueShownAsLabel="true" Color="CornflowerBlue" ChartType="Spline" IsXValueIndexed="true" BorderWidth="2" BorderColor="180, 26, 59, 105" YValueType="Int32"></asp:Series>
			<asp:Series XValueType="string" Name="WorldMusic" IsValueShownAsLabel="true" Color="DarkMagenta" ChartType="Spline" IsXValueIndexed="true" BorderWidth="2" BorderColor="180, 26, 59, 105" YValueType="Int32"></asp:Series>
			<asp:Series XValueType="string" Name="Total" IsValueShownAsLabel="true" Color="BlueViolet" ChartType="Spline" IsXValueIndexed="true" BorderWidth="2" BorderColor="180, 26, 59, 105" YValueType="Int32"></asp:Series>
		</series>
		<chartareas>
			<asp:ChartArea Name="ChartArea1"  BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="None">

				<area3dstyle 
				Rotation="0" Perspective="10" Enable3D="false" 
				PointDepth=35 PointGapDepth=5 LightStyle="None" Inclination="38" 
				IsRightAngleAxes="False" WallWidth="0" IsClustered="true" />
				<position Y="2" Height="94" Width="94" X="2"></position>
				<axisy LineColor="64, 64, 64, 64">
					<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
					<MajorGrid LineColor="64, 64, 64, 64" />
				</axisy>
				<axisx IsMarginVisible=false LineColor="64, 64, 64, 64">
					<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
					<MajorGrid LineColor="64, 64, 64, 64" />
				</axisx>
			</asp:ChartArea>
		</chartareas>
		<legends>
			<asp:Legend Enabled="true" 
			IsTextAutoFit="true"  
			IsDockedInsideChartArea="true" 
			Alignment=Far
			Docking=Top
			DockedToChartArea=NotSet
			Name="Default" 
			BackColor="Transparent" 
			Font="Trebuchet MS, 10pt, style=Bold"></asp:Legend>
		</legends>
	</asp:CHART>
</asp:Content>
