# Secretaria API

## Tags
`.net-8` `ddd` `api` `jwt` `matriculas` `alunos` `cursos`

Este é um sistema API desenvolvido em .NET 8 com arquitetura DDD (Domain-Driven Design), destinado a funcionalidades da secretaria acadêmica. Ele permite a matricula de alunos, atualização de notas, verificação de matrícula, busca de histórico de alunos e listagem de alunos por curso.

## Funcionalidades

### POST /api/Matriculas

Faz a matricula do aluno no curso e envia para a mensageria dados para matricula para email..

### PUT /api/Matriculas

Permite a atualização das notas de um aluno matriculado em um curso.

### POST /api/Matriculas/VerificarMatricula

Verifica se um aluno está matriculado em um curso específico.

### GET /api/Matriculas/BuscarMatriculaPorAluno/{idAluno}

Busca o histórico de matrículas de um aluno específico.

### GET /api/Matriculas/BuscarMatriculaPorCurso/{idCurso}

Lista os alunos matriculados em um curso específico.

## Integração com Sistemas Externos

Este sistema faz integração com os seguintes sistemas externos:
- [Sistema de Usuários](https://github.com/MARIO-IVISA/Usuarios): Utilizado para autenticação de usuários e geração de tokens JWT.
- [Cursos API](https://github.com/MARIO-IVISA/CursosApi): Utilizado para obter informações sobre os cursos e gerar o token JWT.
