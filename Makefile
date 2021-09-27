mutate:
	cd testes/Solucao_Base.Dominio.Testes && dotnet stryker && cd ../..
	cd testes/Solucao_Base.Aplicacao.Testes && dotnet stryker && cd ../..
	
desmutate:
	cd testes/Solucao_Base.Dominio.Testes && rm -rf StrykerOutput && cd ../..
	cd testes/Solucao_Base.Aplicacao.Testes && rm -rf StrykerOutput && cd ../..