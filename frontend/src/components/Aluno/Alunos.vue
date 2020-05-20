<template>
  <div>
    <titulo
      :texto="
        professor_id != undefined
          ? 'Professor: ' + professor.nome
          : 'Todos os Alunos'
      "
    />
    <div v-if="professor_id != undefined">
      <input
        type="text"
        placeholder="Nome do Aluno"
        v-model="nome"
        @keyup.enter="addAluno()"
      />
      <button class="btn btn_add" @click="addAluno()">Adicionar</button>
    </div>
    <br />
    <br />
    <table>
      <thead>
        <th>Mat.</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td class="colPequeno">{{ aluno.id }}</td>
          <router-link
            :to="`/alunoDetalhe/${aluno.id}`"
            tag="td"
            style="cursor: pointer"
          ></router-link>
          <td>{{ aluno.nome }} {{aluno.sobrenome}}</td>
          <td class="colPequeno">
            <button class="btn btn_red" @click="remover(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum aluno cadastrado
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";

export default {
  components: {
    Titulo,
  },
  data() {
    return {
      titulo: "Aluno",
      professor_id: this.$route.params.prof_id,
      professor: {},
      nome: "",
      alunos: [],
    };
  },

  created() {
    /* O $http executa um GET e o retorno deste GET é passado para o ret, que 
       consequentemente possui é uma STRING e deve ser convertida para JSON. Logo,
       este novo resultado já convertido é atribuído para a variável alunos, que por
       sua vez é passado para outro objeto no último "this"*/
    if (this.professor_id) {
      carregarProfessores();
      this.$http
        .get(
          "http://localhost:5000/api/alunos?professor.id=" + this.professor_id
        )
        .then((ret) => ret.json())
        .then((alunos) => (this.alunos = alunos));
    } else {
      this.$http
        .get("http://localhost:5000/api/alunos")
        .then((ret) => ret.json())
        .then((alunos) => (this.alunos = alunos));
    }
  },

  props: {},
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: "",
        professor: {
          id: this.professor.id,
          nome: this.professor.nome,
        },
      };

      this.$http
        .post("http://localhost:5000/api", _aluno)
        .then((ret) => ret.json())
        .then((alunoinserido) => {
          this.alunos.push(alunoinserido);
          this.nome = "";
        });
    },
    remover(aluno) {
      this.$http.delete(`http://localhost:5000/api/${aluno.id}`).then(() => {
        let index = this.alunos.indexOf(aluno);
        this.alunos.splice(index);
      });
    },
    carregarProfessores() {
      this.$http
        .get("http://localhost:5000/api/professores/" + this.professor_id)
        .then((res) => res.json())
        .then((professor) => {
          this.professor = professor;
        });
    },
  },
};
</script>

<style scoped>
input {
  /*Calculo realizado para que o botão fique na frente do Input, caso o "display: inline não for utilizado"*/
  width: calc(100%-195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #9ea3a3;
  display: inline;
}

.btn_add {
  width: 150px;
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  display: inline;
  background-color: rgb(116, 115, 115);
}

.btn_add:hover {
  padding: 20px;
  margin: 0px;
  border: 0px;
}
</style>
