<template>
  <div id="app">
    <Alunos />
  </div>
</template>

<script>
import Alunos from "./components/Aluno/Alunos.vue";

export default {
  name: "App",
  components: {
    Alunos,
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Montserrat:400,700");

body {
  background-color: #eee;
  font-family: "Montserrat", sans-serif;
  display: grid;
  justify-items: center;
}
body,
html {
  margin: 0;
  height: 100%;
}

#app {
}

.btn_red {
  background-color: rgb(236, 51, 88);
}

.btn {
  padding: 10px 20px;
  cursor: pointer;
  border: 1px solid #000;
  color: white;
  font-weight: bold;
  /* Para as bordas do botão ficarem arredondadas */
  border-radius: 5px;
  /* Para aplicar um efeito na borda inferior do botão */
  border-bottom: 3px solid black;
}

/*Aplica um efeito visual sobre o botão quando passamos o cursor sobre o mesmo*/
.btn:hover {
  text-shadow: 1px 1px 1px black;
  margin-top: 3px;
  border-bottom: 1px solid black;
}

table {
  margin: 0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
}

table thead th{
  background-color: rgb(184, 208, 216) !important;
  font-size: 1.2em;
  padding: 10px 0px;
  text-align: center !important;
}

table tr td {
  padding: 20px;
  font-size: 1.3em;
  background-color: #e0edf4;
  margin-bottom: 2px;
  color: #3e5252;
}

.colPequeno {
  width: 5%;
}
</style>
