import { ClipLoader } from 'react-spinners';
import "./Spinner.css";

interface Props {
    isLoading?: boolean;
}

const Spinner = ({isLoading = true}: Props) => {
  return (
    <div>
        <div id='loading-spinner'>
            <ClipLoader color='#36d7b7' loading={isLoading} size={35} aria-label='Loading Spinner' data-testid="loader" />
        </div>
    </div>
  )
}

export default Spinner