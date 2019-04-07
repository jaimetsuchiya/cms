<%@ Page Language="VB"%>
<%@ OutputCache Location="None" VaryByParam="none"%>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If Not Page.IsPostBack Then
            If Not IsNothing(Session("content-bootstrap")) Then
                litContent.Text = Session("content-bootstrap")
            Else
                'Sample content
                litContent.Text = "<div class=""is-section is-section-100 is-light-text is-box is-align-right"">" & _
                        "<div class=""is-overlay"">" & _
                            "<div class=""is-overlay-bg"" style=""background-image: url(contentbox/images/sample4.jpg);""></div>" & _
                            "<div class=""is-overlay-color"" style=""opacity: 0.1;""></div>" & _
                        "</div>" & _
                        "<div class=""is-boxes"">" & _
                            "<div class=""is-box-centered is-opacity-95"">" & _
                                "<div class=""is-container is-builder container is-content-right is-content-640"">" & _
                                    "<div class=""row clearfix"">" & _
                                        "<div class=""column full"">" & _
                                            "<div class=""display"">" & _
                                                "<h1>A new point of view</h1>" & _
                                                "<p>Lorem Ipsum is simply dummy text of the printing industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.</p>" & _
                                            "</div>" & _
                                        "</div>" & _
                                    "</div>" & _
                                    "<div class=""row clearfix"">" & _
                                        "<div class=""column full"">" & _
                                            "<a href=""#"" class=""is-btn is-btn-ghost1 is-upper is-rounded-30 is-btn-small edit"" title="""">Contact Us</a>" & _
                                        "</div>" & _
                                    "</div>" & _
                                "</div>" & _
                            "</div>" & _
                        "</div>" & _
                    "</div>"
            End If
            
            If Not IsNothing(Session("mainCss-bootstrap")) Then
                Header.Controls.Add(New LiteralControl(Session("mainCss-bootstrap")))
            End If
            
            If Not IsNothing(Session("sectionCss-bootstrap")) Then
                Header.Controls.Add(New LiteralControl(Session("sectionCss-bootstrap")))
            End If

        End If

    End Sub
      
</script>

<!DOCTYPE HTML>
<html>
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>Default Example</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
      
    <link href="box/box.css" rel="stylesheet" type="text/css" />
    <link href="assets/minimalist-blocks/content.css" rel="stylesheet" type="text/css" />    
    <link href="assets/scripts/simplelightbox/simplelightbox.css" rel="stylesheet" type="text/css" /> <!-- Lightbox -->
</head>
<body>

<div class="is-wrapper">
    <asp:Literal ID="litContent" runat="server"></asp:Literal>
</div>

<script src="contentbuilder/jquery.min.js" type="text/javascript"></script>  
<script src="assets/scripts/simplelightbox/simple-lightbox.min.js" type="text/javascript"></script> <!-- Lightbox -->
<script src="box/box.js" type="text/javascript"></script>

</body>
</html>