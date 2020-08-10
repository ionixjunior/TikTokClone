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
                    Link = "https://v16m.tiktokcdn.com/5a1c25ea2ab48981a704a0d993fc4a5f/5f322faa/video/tos/useast2a/tos-useast2a-ve-0068c004/9fa3da104133427b84799ab69672417d/?a=1233",
                    Description = "#viral #foryou",
                    AccountName = "@petrokill",
                    AccountAvatar = "https://p16-va-tiktok.ibyteimg.com/img/musically-maliva-obj/1659910425753606~c5_100x100.jpeg",
                    IsVerifiedAccount = false,
                    SongName = "Woah - KRYPTO9095",
                    SongAvatar = "https://p16-tiktokcdn-com.akamaized.net/aweme/100x100/tos-alisg-i-0000/dd58c8fc85e343de916d19eed732e7db.jpeg",
                    Likes = 548,
                    Messages = 1800,
                    Shares = 938
                }
            );
            Videos.Add(
                new Video
                {
                    Link = "https://v16m.tiktokcdn.com/68c864d8d48e18d6616133bfcc6c4529/5f324629/video/tos/useast2a/tos-useast2a-ve-0068/7fcc89a31a364ca9a651169fa1ba9d49/?a=1233",
                    Description = "First one hit HARD😬😱 Can you guys name this sport? #leeds #featureit #tiktok #challenge 🔥",
                    AccountName = "@davidnelmes",
                    AccountAvatar = "https://p16-va-tiktok.ibyteimg.com/img/musically-maliva-obj/1650464633250822~c5_100x100.jpeg",
                    IsVerifiedAccount = true,
                    SongName = "Dance Monkey - Tones and I",
                    SongAvatar = "https://p16-tiktokcdn-com.akamaized.net/aweme/100x100/tos-alisg-i-0000/acfc564d3a2a442cb8eb02f31b982a1f.jpeg",
                    Likes = 3929,
                    Messages = 2993,
                    Shares = 902
                }
            );
            Videos.Add(
                new Video
                {
                    Link = "https://v16m.tiktokcdn.com/2d7f5cbc789404762dfbdc2559383be3/5f324765/video/tos/useast2a/tos-useast2a-pve-0068/d7006567a407408685a9c0d5f6f24401/?a=1233",
                    Description = "Giro de músculo ♥️ #secuida #treino #isolamento",
                    AccountName = "@anacoll_",
                    AccountAvatar = "https://p16-va-tiktok.ibyteimg.com/img/musically-maliva-obj/1661618425472005~c5_100x100.jpeg",
                    IsVerifiedAccount = false,
                    SongName = "som original - anacoll_",
                    SongAvatar = "https://p16-va-tiktok.ibyteimg.com/img/musically-maliva-obj/1661618425472005~c5_100x100.jpeg",
                    Likes = 9103,
                    Messages = 88,
                    Shares = 59
                }
            );
        }
    }
}
