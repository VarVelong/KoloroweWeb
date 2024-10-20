<template>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Kolorowe Przedszkole</title>
</head>
<body>
    <header>
        <div class="logo">Kolorowe Przedszkole</div>
        <nav>
            <ul>
                <button>O nas</button>
                <button>Aktualności</button>
                <button>Oferta</button>
                <button>Kadra</button>
            </ul>
        </nav>
    </header>

    <div class="main">
        <h1>Witamy w kolorowym przedszkolu</h1>
        <a class="cta-button">Umów wizytę</a>
    </div>

    <div>
        <h2>O nas</h2>
        <p>bla bla bla</p>
    </div>

    <div>
        <h2>Nasza oferta</h2>
        <div class="program">
            <h3>Oferta 1</h3>
        </div>
        <div class="program">
            <h3>Oferta 2</h3>
        </div>
    </div>

    <div>
        <h2>Kontakt</h2>
        <form>
            <input type="text" placeholder="Imię" required>
            <input type="email" placeholder="Email" required>
            <textarea placeholder="Twoja Wiadomość" required></textarea>
            <button type="submit">Wyślij</button>
        </form>
        <p>Telefon: 123 456 789</p>
        <p>Email: biuro@kolorowe.gda.pl</p>
    </div>

    <footer>
        <p>&copy; 2024 Kolorowe Przedszkole.</p>
    </footer>
</body>
</template>

<style scoped>
body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
}

header {
    background: #4CAF50;
    color: white;
    padding: 10px 20px;
    display: flex;
    justify-content: space-between;
    align-items: center;
}

nav ul {
    list-style: none;
    display: flex;
    gap: 15px;
}

nav a {
    color: white;
    text-decoration: none;
}

.main {
    background: greenyellow;
    padding: 50px;
    text-align: center;
}

.cta-button {
    background: #4CAF50;
    color: white;
    padding: 10px 20px;
    text-decoration: none;
}

div {
    padding: 20px;
    margin: 10px;
}

.program {
    border: 1px solid #ccc;
    padding: 10px;
    margin: 10px 0;
}

footer {
    background: #333;
    color: white;
    text-align: center;
    padding: 10px;
    position: relative;
    bottom: 0;
    width: 100%;
}
</style>
