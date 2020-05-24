import Vue from "vue";
import Router from "vue-router";
import Alunos from "./components/Aluno/Alunos";
import AlunosDetalhe from "./components/Aluno/AlunosDetalhe";
import Professor from "./components/Professor/Professor";
import Sobre from "./components/Sobre/Sobre";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      nome: 'Professores',
      component: Professor
  },
  {
      path: '/professores',
      nome: 'Professores',
      component: Professor
  },
  {
      path: '/alunos/:prof_id',
      nome: 'Alunos',
      component: Alunos
  },
  {
      path: '/todosAlunos',
      nome: 'Alunos',
      component: Alunos
  },
  {
      path: '/alunosDetalhe/:id',
      nome: 'AlunosDetalhe',
      component: AlunosDetalhe
  },
  {
      path: '/sobre',
      nome: 'Sobre',
      component: Sobre
  }
  ],
});
