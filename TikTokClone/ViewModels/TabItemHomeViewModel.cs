using System;
using MvvmHelpers;
using TikTokClone.Models;

namespace TikTokClone.ViewModels
{
    public class TabItemHomeViewModel
    {
        public ObservableRangeCollection<Video> Videos { get; private set; }

        public TabItemHomeViewModel()
        {
            Videos = new ObservableRangeCollection<Video>();

            Videos.Add(
                new Video
                {
                    Link = "https://www.ionixjunior.com.br/wp-content/uploads/2020/08/video1.mov",
                    Description = "Can’t believe I saw this #fyp #Chucky #scared #funny",
                    AccountName = "@emojiworld19",
                    AccountAvatar = "https://lh3.googleusercontent.com/a-/AOh14GgQzrEIrIO3xWk9rYpyNZSjUKocdDKhnvTP1VEPew=s96-c",
                    IsVerifiedAccount = false,
                    SongName = "original sound - zodic_signszs12",
                    SongAvatar = "https://p16-tiktok-va-h2.ibyteimg.com/img/musically-maliva-obj/1658303418692613~c5_100x100.jpeg",
                    Likes = 1477,
                    Messages = 1718,
                    Shares = 137
                }
            );
            Videos.Add(
                new Video
                {
                    Link = "https://www.ionixjunior.com.br/wp-content/uploads/2020/08/video2.mp4",
                    Description = "New Orleans is wild #FeelTheFlip #SummerLooks #SNOOZZZAPALOOZA #BehindTheSong #BrowFitness #fyp",
                    AccountName = "@pudgiest",
                    AccountAvatar = "https://p16-tiktok-va-h2.ibyteimg.com/img/musically-maliva-obj/78c716e12210fc3cde6e37d7857ef292~c5_100x100.jpeg",
                    IsVerifiedAccount = false,
                    SongName = "Gang Up（from \"The Fate of the Furious\"） - Young Thug,2 Chainz,Wiz Khalifa",
                    SongAvatar = "https://p16-tiktok-sg-h2.ibyteimg.com/aweme/100x100/iesmusic-sg-local/v1/m/c150007f2c640e6b236.jpeg",
                    Likes = 19,
                    Messages = 9030,
                    Shares = 1071
                }
            );
            Videos.Add(
                new Video
                {
                    Link = "https://www.ionixjunior.com.br/wp-content/uploads/2020/08/video3.mp4",
                    Description = "How many dogs can you spot❓#SNOOZZZAPALOOZA #PhotoStory #MiracleCurlsChallenge #FeelTheFlip #foryoupage #goldenretriever #ellendegeneres",
                    AccountName = "@golden.retriever.trio",
                    AccountAvatar = "https://p16-tiktok-va-h2.ibyteimg.com/img/musically-maliva-obj/1663058121994246~c5_100x100.jpeg",
                    IsVerifiedAccount = false,
                    SongName = "original sound - destinysciuva",
                    SongAvatar = "https://p16-tiktok-va-h2.ibyteimg.com/img/musically-maliva-obj/1663246946669574~c5_100x100.jpeg",
                    Likes = 1933,
                    Messages = 5109,
                    Shares = 345
                }
            );
        }
    }
}
