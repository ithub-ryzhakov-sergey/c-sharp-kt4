using System;
using System.IO;
using App.Topics.ThrowFinally.T1_3_RethrowAndWrapping;
using NUnit.Framework;

namespace App.Tests.Topics.ThrowFinally.T1_3_RethrowAndWrapping;

public class ConfigLoaderTests
{
    [Test]
    public void NullOrWhiteSpacePath_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => ConfigLoader.LoadConfig(null!));
        Assert.Throws<ArgumentException>(() => ConfigLoader.LoadConfig(" "));
    }

    [Test]
    public void MissingFile_IsWrappedIntoConfigurationErrorsException()
    {
        var ex = Assert.Throws<ConfigurationErrorsException>(() => ConfigLoader.LoadConfig("/definitely/missing/file.json"));
        Assert.That(ex!.InnerException, Is.TypeOf<FileNotFoundException>());
    }

    [Test]
    public void OtherExceptions_AreRethrownAsIs()
    {
        // Используем недопустимый путь, который обычно вызывает ArgumentException у File.ReadAllText
        Assert.Throws<ArgumentException>(() => ConfigLoader.LoadConfig("\0invalid"));
    }
}
