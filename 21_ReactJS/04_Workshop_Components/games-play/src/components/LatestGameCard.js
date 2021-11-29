//import { Link } from 'react-router-dom';

const LatestGameCard = ({
    game,
    navigationChangeHandler,
}) => {
    const onDetailsClick = (e) => {
        e.preventDefault();
        navigationChangeHandler(`/details/${game._id}`);
    };

    return (
        <div className="game">
            <div className="image-wrap">
                <img src={game.imageUrl} />
            </div>
            <h3>{game.title}</h3>
            <div className="rating">
                <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
            </div>
            <div class="data-buttons">
                <a
                    href={`/details/${game._id}`}
                    onClick={onDetailsClick}
                    class="btn details-btn"
                >
                    Details
                </a>
            </div>
        </div>
    );
};

export default LatestGameCard;