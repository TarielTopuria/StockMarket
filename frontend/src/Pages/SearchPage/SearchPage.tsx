import Navbar from '../../Navbar/Navbar'
import Hero from '../../Hero/Hero'
import CardList from '../../Components/CardList/CardList'
import ListPortfolio from '../../Components/Portfolio/ListPortfolio/ListPortfolio'
import Search from '../../Components/Search/Search'
import { useState, ChangeEvent, SyntheticEvent } from 'react'
import { searchCompanies } from '../../api'
import { CompanySearch } from '../../company'

interface Props {
    
}

const SearchPage = (props: Props) => {
  const [search, setSearch] = useState<string>("");
  const [portfolioValues, setPortfolioValues] = useState<string[]>([]);
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string>("");
  
  const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => 
  {
    setSearch(e.target.value);
    console.log(e);
  };

  const onPortfolioCreate = (e: any)=>
  {
    e.preventDefault();
    const exists = portfolioValues.find((value) => value === e.target[0].value);
    if(exists) return;
    const updatedPortfolio = [...portfolioValues, e.target[0].value];
    setPortfolioValues(updatedPortfolio);
  }

  const onSearchSubmit = async (e: SyntheticEvent) => 
  {
    e.preventDefault();
    const result = await searchCompanies(search);

    if(typeof result === "string"){
      setServerError(result);
      console.log(serverError);
    }else if (Array.isArray(result.data)){
      setSearchResult(result.data);
    };
    
    console.log(searchResult);
  };

  const onPortfolioDelete = (e : any) => {
    e.preventDefault();
    const removed = portfolioValues.filter((value) => {
      return value !== e.target[0].value;
    })

    setPortfolioValues(removed);
  }

  return (
    <div className="App">
      <Search onSearchSubmit={onSearchSubmit} handleSearchChange={handleSearchChange} search={search}/>
      {serverError && <h1>{serverError}</h1>}
      <ListPortfolio portfolioValues={portfolioValues} onPortfolioDelete={onPortfolioDelete}/>
      <CardList searchResults={searchResult} onPortfolioCreate={onPortfolioCreate}/>
      {serverError && <div>Unable to connect to API</div>}
    </div>
  )
}

export default SearchPage