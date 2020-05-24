<template>
  <div>
    <titulo texto="Professores" :btn_voltar="true"/>
    <table>
      <thead>
        <th>Cód.</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="Professores.length">
        <tr v-for="(professor, index) in Professores" :key="index">
          <td class="colPequeno">{{professor.id_professor}}</td>

          <router-link
            :to="`/alunos/${professor.id_professor}`"
            tag="td"
            style="cursor: pointer"
          >{{professor.nome}} {{professor.sobrenome}}</router-link>

          <td class="colPequeno">{{professor.qtdAlunos}}</td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center">
            <h5>Nenhum Professor Encontrado</h5>
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
      Professores: [],
      Alunos: [],
    };
  },
  created() {
    /* O $http executa um GET e o retorno deste GET é passado para o ret, que
       consequentemente possui é uma STRING e deve ser convertida para JSON. Logo,
       este novo resultado já convertido é atribuído para a variável Professores, que por
       sua vez é passado para outro objeto no último "this"*/
    this.$http
      .get("http://localhost:5000/api/alunos")
      .then((ret) => ret.json())
      .then((alunos) => {
        this.Alunos = alunos;
        this.carregarProfessores();
      });
  },

  props: {},
  methods: {
    // alunosPorProfessor() {
    //   this.Professores.array.forEach((professor, index) => {
    //     professor = {
    //       id_professor: professor.id_professor,
    //       nome: professor.nome,
    //       qtdAlunos: this.Alunos.filter(
    //         (aluno) => aluno.professor.id_professor == professor.id_professor
    //       ).length,
    //     };
    //     this.Professores[index] = professor;
    //   });
    // },

    carregarProfessores() {
      this.$http
        .get("http://localhost:5000/api/professores")
        .then((res) => res.json())
        .then((professor) => {
          this.Professores = professor;
          // this.alunosPorProfessor();
        });
    },
  },
};
</script>

<style scoped>
.colPequeno {
  text-align: center;
  width: 20%;
}

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
