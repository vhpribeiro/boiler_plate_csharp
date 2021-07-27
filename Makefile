executarTestesMutantes:
	cd testes/Solucao_Base.Dominio.Testes && dotnet stryker && cd ../..
	cd testes/Solucao_Base.Aplicacao.Testes && dotnet stryker && cd ../..
	cd testes/Solucao_Base.Infra.Testes && dotnet stryker && cd ../..
	
excluirRegistroTestesMutante:
	cd testes/Solucao_Base.Dominio.Testes && rm -rf StrykerOutput && cd ../..
	cd testes/Solucao_Base.Aplicacao.Testes && rm -rf StrykerOutput && cd ../..
	cd testes/Solucao_Base.Infra.Testes && rm -rf StrykerOutput && cd ../..