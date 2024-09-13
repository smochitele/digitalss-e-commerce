<%@ Page Title="" Language="C#" MasterPageFile="~/RootLayout.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="DSS_Website.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Contact Us | DigitalSS
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/main.css">
    <link rel="stylesheet" href="css/imagehover.min.css">
    <link rel="stylesheet" href="../css/login.css">
	<link rel="stylesheet" href="https://cdn.rawgit.com/openlayers/openlayers.github.io/master/en/v5.3.0/css/ol.css" type="text/css">
	<script src="https://cdn.rawgit.com/openlayers/openlayers.github.io/master/en/v5.3.0/build/ol.js"></script>
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <style>
      .map {
        height: 470px;
        width: 100%;
      }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="contact_us">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6">
                    <form class="message-form" style="height:0%;" runat="server">
                        <br />
                        <h2>Talk To Us</h2>
                        <div class="input-register">
                            <label for="name">Full Name</label>
                            <input type="text" name="name" placeholder="Enter your name" id="names" runat="server">
                        </div>
                        <div class="input-register">
                            <label for="email">Email</label>
                            <input type="text" name="name"  placeholder="Enter your email" id="email" runat="server"> 
                        </div>
                        <div class="input-register">
                            <label for="subject">Subject</label>
                            <input type="text" name="subject" id="subject" placeholder="Enter The Subject Line" runat="server">
                        </div>
                        <div class="input-register">
                            <label for="message">Message</label>
                            <textarea name="message" id="message" cols="30" rows="10" placeholder="Message here..." runat="server"></textarea>
                        </div>
                        <div class="input-register" >
                            <asp:button  runat="server"  id="btnSend" Text="Send Message" OnClick="btnSend_Click"/>
                        </div>
                    </form>
                    <br />
                    <br />
                </div>
                <div class="col-md-6">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <h2 style="margin-top: -10px;">Where To Find Us</h2>
                    <label for="name">Location Of Our Store</label>
                <div class="mapouter">
                    <div id="map" class="map"></div>
               <script>
                   var attribution = new ol.control.Attribution({
                       collapsible: false
                   });

                   var map = new ol.Map({
                       controls: ol.control.defaults({ attribution: false }).extend([attribution]),
                       layers: [
                           new ol.layer.Tile({
                               source: new ol.source.OSM({
                               })
                           })
                       ],
                       target: 'map',
                       view: new ol.View({
                           center: ol.proj.fromLonLat([27.997716734031656, -26.18358782116568]),
                           maxZoom: 18,
                           zoom: 16.8
                       })
                   });
                   var layer = new ol.layer.Vector({
                       source: new ol.source.Vector({
                           features: [
                               new ol.Feature({
                                   geometry: new ol.geom.Point(ol.proj.fromLonLat([27.996110024102688, -26.18259184354212]))
                               })
                           ]
                       })
                   });
                   map.addLayer(layer);
		</script>
             </div>
           </div>
          </div>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <div class="locat">
                        <h3>Our Location On Campus</h3>
                        <h4><i class="fas fa-store"></i>Shop No. 22</h4>
                        <h4>&nbsp;Student Center</h4>
                        <h4>&nbsp;University of Johannesburg - APK</h4>
                        <h4><i class="fas fa-envelope"></i>digitalss@info.com</h4>
                        <h4><i class="fas fa-phone"></i>063 3633 6363</h4>
                    </div>
                </div>
                <div class="col-md-4"></div>
            </div>
         </div>
        </div>
</asp:Content>
