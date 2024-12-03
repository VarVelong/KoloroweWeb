<template>
    <body>
        <div id="map"></div>
        <div>
            <h2>O nas</h2>
            <p>bla bla bla</p>
        </div>
    </body>
</template>

<script>
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';

export default {
  mounted() {
    const map = L.map('map').setView([54.36102338196047, 18.55556593945651], 15);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '© OpenStreetMap contributors',
    }).addTo(map);

    L.marker([54.36102338196047, 18.55556593945651]).addTo(map)
      .bindPopup('Kolorowe przedszkole jest tutaj!')
      .openPopup();
  },
};
</script>


<style scoped>
body {
    background-color:#4CAF50;
    margin: 0 auto; 
    padding: 0;
    color: #333;
    width: 80%; 
    box-sizing: border-box; 
    display: flex;
    flex-direction: column;
}

div {
    background-color: #FFF9C4; 
    border: 3px solid #FFD54F;
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    max-width: 600px; 
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    text-align: center; 
}

h2 {
    color: #FF6F61; 
    font-size: 2em;
    margin-bottom: 10px;
    text-shadow: 1px 1px #FFD9E8;
}

p {
    font-size: 1.2em;
    line-height: 1.5;
    margin: 5px 0;
    color: #555; 
}

#map{
    height: 500px;
    width: 500px;
}
</style>