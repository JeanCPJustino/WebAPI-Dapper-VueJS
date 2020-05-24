<template>
  <div>
    <titulo :texto="id_professor != undefined ? 'Professor: ' + professor.nome : 'Todos os Alunos'" :btn_voltar="true"
    />
    <div v-if="id_professor != undefined">
      <input type="text" placeholder="Nome do Aluno" v-model="nome" @keyup.enter="addAluno()">
      <button class="btn btn_add" @click="addAluno()">Adicionar</button>
    </div>

    <table>
      <thead>
        <th>Mat.</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td class="colPequeno">{{aluno.id_aluno}}</td>
          <router-link :to="`/alunosDetalhe/${aluno.id_aluno}`" tag="td" style="cursor: pointer">
            {{aluno.nome}} {{aluno.sobrenome}}
          </router-link>
          <td class="colPequeno">
            <Button class="btn btn_red" @click="remover(aluno)">Remover</Button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
         <tr>
          <td colspan="3" style="text-align: center">
            <h5>Nenhum Aluno Encontrado</h5>
          </td>
        </tr>
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
      id_professor: this.$route.params.prof_id,
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
    if (this.id_professor) {
      this.carregarProfessores();
      this.$http
        .get(`http://localhost:5000/api/alunos/byprofessor/${this.id_professor}`)
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    } else {
      this.$http
        .get("http://localhost:5000/api/alunos")
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    }
  },

  props: {},
  methods: {
    addAluno() {
      let _aluno = {
        id_aluno: 0,
        nome: this.nome,
        sobrenome: "",
        dataNascimento: "01/01/2000",
        id_professor: this.professor.id_professor,
        professor: {
           id_professor: this.professor.id_professor,
           nome: this.professor.nome,
        } 
      };

      this.$http
        .post("http://localhost:5000/api/alunos/", _aluno)
        .then((res) => res.json())
        .then((aluno) => {
          this.alunos.push(aluno);
          this.nome = "";
        });
    },
    remover(aluno) {
      this.$http.delete(`http://localhost:5000/api/alunos/${aluno.id_aluno}`).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    },
    carregarProfessores() {
      this.$http
        .get(`http://localhost:5000/api/professores/${this.id_professor}`)
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
