<template>
    <body>

        <div class="main">
            <h1>Witamy w kolorowym przedszkolu</h1>
            <button id="a-button" @click="$router.push({ name: 'offer'})">Zobacz naszą ofertę</button>
            <button id="a-button" @click="$router.push({ name: 'contact'})">Umów wizytę</button>
        </div>



    </body>
</template>

<style scoped>
body {
    background-color:#4CAF50;
    margin: 0 auto; 
    padding: 0;
    color: #333;
    width: 90%;
    box-sizing: border-box; 
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
</style>

