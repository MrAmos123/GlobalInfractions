﻿using System.Text.Json.Serialization;
using SharedLibraryCore;

namespace BanHub.Configuration;

public class BanHubConfiguration
{
    [JsonIgnore] public const string Name = "Ban Hub";
    public bool EnableBanHub { get; set; } = true;
    [JsonPropertyName("ApiKeyDoNotChange")] public Guid ApiKey { get; set; } = Guid.NewGuid();
    public string? InstanceNameOverride { get; set; }
    public string? InstanceWebsite { get; set; }
    public bool PrintPenaltyToConsole { get; set; } = false;
    public TranslationStrings Translations { get; set; } = new();
    public bool DebugMode { get; set; } = false;
}

public class TranslationStrings
{
    // @formatter:off
    // ReSharper disable once InconsistentNaming
    public string BanHubName { get; set; } = "[(Color::Accent)BanHub(Color::White)]";
    public string CannotAuthIW4MAdmin { get; set; } = "{{plugin}} You cannot authenticate as IW4MAdmin";
    public string NotActive { get; set; } = "{{plugin}} is not active";
    public string GlobalBanCommandSuccess { get; set; } = "{{plugin}} banned {{target}} for {{reason}} ({{guid}})";
    public string GlobalBanCommandSuccessFollow { get; set; } = "{{plugin}} (Color::Yellow)You must upload (Color::Accent)!{{command}} (Color::Yellow)for global bans!";
    public string GlobalBanCommandFail { get; set; } = "{{plugin}} Ban Hub ban was not submitted";
    public string SubmitEvidenceSuccess { get; set; } = "{{plugin}} Evidence submitted";
    public string SubmitEvidenceFail { get; set; } = "{{plugin}} Failed to submit evidence. Does the penalty exist or have evidence already?";
    public string SubmitEvidenceUrlFail { get; set; } = "{{plugin}} Evidence must be a valid YouTube URL";
    public string CannotTargetServer { get; set; } = "{{plugin}} You cannot ban the console...";
    public string ProvideToken { get; set; } = "{{plugin}} Your token is {{token}} (expires in 5 minutes)";
    public string TokenGenerationFailed { get; set; } = "{{plugin}} Failed to generate token";
    public string UserHasNotes { get; set; } = "{{plugin}} (Color::Accent){{user}} (Color::White)has (Color::Yellow){{count}} (Color::White)note(s). (Color::Yellow)Check the website for more info.";
    // @formatter:on
}
